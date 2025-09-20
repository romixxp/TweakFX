using System;
using NAudio.Wave;
using System.Windows.Forms;
using System.Threading;
using TweakFX.core.effects.distortion;
using TweakFX.ui.controls;
using dfsa.ui;
using TweakFX.core.effects.delay_reverb;
using System.Reflection.Metadata.Ecma335;
using TweakFX.core.mics;
using System.Threading.Tasks;
using TweakFX.core.effects.pitch;
using TweakFX.core.effects.spatial;
using TweakFX.core.effects.dynamics;
using System.Diagnostics;
using TweakFX.core.effects.eq;
using TweakFX.core.effects;

namespace TweakFX.core
{
    public class AudioEngine : IDisposable
    {
        public event Action<float[]> OnBufferProcessed;
        private readonly AsioConfig _config;
        //private readonly AsioInput _asioInput;
        //private readonly AsioOutput _asioOutput;
        private readonly EffectChain _effectChain;
        private float volume = 1.0f;
        private float involume = 1.0f;
        private float mix = 0.5f;
        private float processFraction = 1.0f;
        private VBCableAudioSender sender = new VBCableAudioSender();
        private float WASAPIlevel = 1f;

        public AudioEngine(AsioConfig config)
        {
            _config = config;

            _effectChain = new EffectChain();
        }


        Clipper2 clipper;
        Delay delay;
        Reverb reverb;
        PitchShifter pitchShifter; 
        Spatializer spatializer;
        NoiseReducer noiseReducer;
        Equalizer equalizer;
        Compressor compressor;

        #region Updaters

        #region Distortion

        public void UpdDist(float newDistortionAmount) => clipper.UpdateDistortionAmount(newDistortionAmount);
        public void UpdTone(float newTone) => clipper.UpdateTone(newTone);
        public void UpdThres(float newThres) => clipper.UpdateThreshold(newThres);
        public void UpdVol(float newVolume) => clipper.UpdateVolume(newVolume);

        #endregion

        #region Delay

        public void UpdDelayTime(int delayTimeInMs) => delay.UpdateDelayTime(delayTimeInMs);
        public void UpdFeedback(float feedback) => delay.UpdateFeedback(feedback);
        public void UpdWetMix(float wetMix) { delay.UpdateWetMix(wetMix); delay.UpdateDryMix(1f - wetMix); }

        #endregion

        #region Reverb

        public void UpdDecay(float newdecay) => reverb.SetDecay(newdecay);
        public void UpdDamping(float newdamping) => reverb.SetDamping(newdamping);
        public void UpdPreDelay(float newpredelay) => reverb.SetPreDelay(newpredelay);
        public void UpdWetMixReverb(float wetMix) => reverb.SetDryWetMix(wetMix, 1f - wetMix);

        #endregion

    
        #region Compressor

        public void UpdCompThres(float newThres) => compressor.UpdateThres(newThres);
        public void UpdRatio(float newRatio) => compressor.UpdateRatio(newRatio);
        public void UpdAttack(float newAttack) => compressor.UpdateAttack(newAttack);
        public void UpdRelease(float newRelease) => compressor.UpdateRelease(newRelease);
        public void UpdMakeUp(float newMakeUp) => compressor.UpdateAttack(newMakeUp);
        
        #endregion


        #region Pitch Shifter

        public void UpdPitchShift(float pitchShift) => pitchShifter.SetPitchShift(pitchShift*2);
        public void UpdPitchShiftMix(float mix) => pitchShifter.Mix = mix;

        #endregion

        #region Spatializer

        public void UpdAzimuth(float azimuth) => spatializer.SetAzimuth(azimuth);

        #endregion

        #region EQ

        public void EQSetDryWetMix(float drywet) => equalizer.SetDryWetMix(drywet);
        public void EQUpdateBands(List<EqualizerBand> _bands) => equalizer.UpdateBands(_bands);

        #endregion

        public float SetInVol(float vol) { return volume = vol * 2f; }
        public float SetOutVol(float vol) { return involume = vol * 2f; }
        public float SetASIOOutputLevel(float level) { return Program.asioOutput.SetVolume(level); }
        public float SetWASAPIOutputLevel(float level) { return WASAPIlevel = level; }
        public float SetMix(float mix) { return this.mix = mix; }

        #endregion

        SquareWaveGenerator generator = new SquareWaveGenerator(44100, 2000, durationSeconds: 2);
        public async Task Start(int samplerate = 44100)
        {
            Program.asioInput = new AsioInput();
            Program.asioOutput = new AsioOutput();
            var bands = new List<EqualizerBand>
            {
                new EqualizerBand
                {
                    Frequency = 60,
                    Gain = 20f,
                    FilterType = FilterType.LowShelf
                },
                new EqualizerBand
                {
                    Frequency = 150,
                    Gain = 0f,
                    Bandwidth = 1f,
                    FilterType = FilterType.Peaking
                },
                new EqualizerBand
                {
                    Frequency = 400,
                    Gain = 0f,
                    Bandwidth = 1f,
                    FilterType = FilterType.Peaking
                },
                new EqualizerBand
                {
                    Frequency = 1000,
                    Gain = 0f,
                    Bandwidth = 1f,
                    FilterType = FilterType.Peaking
                },
                new EqualizerBand
                {
                    Frequency = 2400,
                    Gain = 0f,
                    Bandwidth = 1f,
                    FilterType = FilterType.Peaking
                }
            };
            Program.asioOutput.Init(samplerate);
            _effectChain.Clear();
            clipper = new core.effects.distortion.Clipper2();
            delay = new core.effects.delay_reverb.Delay(250, sampleRate: _cvars.ASIO_samplerate);
            //Debug.WriteLine($"Delay sample rate: {_cvars.ASIO_samplerate}");
            reverb = new core.effects.delay_reverb.Reverb(decayMs: 1500, preDelayMs: 0, sampleRate: _cvars.ASIO_samplerate);
            pitchShifter = new PitchShifter(1f, 50, sampleRate: _cvars.ASIO_samplerate);
            spatializer = new(0f);
            noiseReducer = new NoiseReducer();
            equalizer = new Equalizer(bands, sampleRate: 44100);
            //DistortionNeonPedal form = new();

            _effectChain.AddEffect(clipper);
            _effectChain.AddEffect(delay);
            _effectChain.AddEffect(reverb);
            _effectChain.AddEffect(pitchShifter);
            //_effectChain.AddEffect(spatializer);
            _effectChain.AddEffect(equalizer);
            

            //_effectChain.AddEffect(noiseReducer);
            /*float[] _buffer = { 0 };
            for (int i = 0; i < 5; i++)
           
                generator.FillBuffer(_buffer);
                _asioOutput.Write(_buffer);
                await Task.Delay(250);
            }*/
            EventHandler<float[]> onAudioAvailable;
            onAudioAvailable = (s, buffer) =>
            { 
                float[] dryBuffer = buffer.ToArray();

                int processedSamples = (int)(buffer.Length * processFraction); // processFraction от 0.0 до 1.0
                if (processedSamples > 0)
                {
                    _effectChain.Process(buffer, 0, processedSamples);
                }

                if (processedSamples < buffer.Length)
                {
                    Array.Copy(dryBuffer, processedSamples, buffer, processedSamples, buffer.Length - processedSamples);
                }
                for (int i = 0; i < buffer.Length; i++)
                {
                    buffer[i] = dryBuffer[i] * (1f - mix) + buffer[i] * mix;
                }
                //for (int i = 0; i < buffer.Length; i++)
                //    buffer[i] *= volume;

                var stereoBuffer = MonoToStereo(buffer);
                Program.asioOutput.Write(stereoBuffer);
                for (int i = 0; i < stereoBuffer.Length; i++)
                    stereoBuffer[i] *= WASAPIlevel;
                sender.SendBuffer(FloatToPcm16Bytes(stereoBuffer));

                lock (_bufferLock)
                {
                    _lastBuffer = buffer.ToArray();
                }
            };
            Program.asioInput.AudioAvailable -= onAudioAvailable;
            Program.asioInput.AudioAvailable += onAudioAvailable;
            Program.asioInput.Start();
        }

        private float[] _lastBuffer = Array.Empty<float>();
        private readonly object _bufferLock = new();

        public float[] GetLatestBuffer()
        {
            lock (_bufferLock)
            {
                return _lastBuffer.ToArray();
            }
        }

        public async Task Stop()
        {
            Program.asioInput.Stop().Wait();
            Program.asioOutput.Stop().Wait(); 
        }

        private float[] MonoToStereo(float[] mono)
        {
            float[] stereo = new float[mono.Length * 2];
            for (int i = 0; i < mono.Length; i++)
            {
                stereo[2 * i] = mono[i];      // Left
                stereo[2 * i + 1] = mono[i];  // Right
            }
            return stereo;
        }

        private byte[] FloatToPcm16Bytes(float[] floatBuffer)
        {
            byte[] byteBuffer = new byte[floatBuffer.Length * 2];
            for (int i = 0; i < floatBuffer.Length; i++)
            {
                short sample = (short)(Math.Clamp(floatBuffer[i], -1.0f, 1.0f) * short.MaxValue);
                byteBuffer[i * 2] = (byte)(sample & 0xFF);
                byteBuffer[i * 2 + 1] = (byte)((sample >> 8) & 0xFF);
            }
            return byteBuffer;
        }
        public void Dispose()
        {
            Stop().Wait();
            sender.Dispose();
        }

    }
}
