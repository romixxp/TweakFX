using System;
using NAudio.Wave;
using System.Windows.Forms;
using TweakFX; // Где лежит AsyncVirtualMicrophoneSender
using System.Threading;
using TweakFX.core.effects.distortion;
using TweakFX.ui.controls;
using dfsa.ui;
using TweakFX.core.effects.delay_reeverb;
using System.Reflection.Metadata.Ecma335;

namespace TweakFX.core
{
    public class AudioEngine : IDisposable
    {
        public event Action<float[]> OnBufferProcessed;
        private readonly AsioConfig _config;
        private readonly AsioInput _asioInput;
        private readonly AsioOutput _asioOutput;
        private readonly EffectChain _effectChain;
        private float volume = 1.0f;
        private float involume = 1.0f;
        private float mix = 0.5f;
        private float processFraction = 1.0f;
        private VBCableAudioSender sender = new VBCableAudioSender();

        public AudioEngine(AsioConfig config)
        {
            _config = config;
            _asioInput = new AsioInput(config);
            _asioOutput = new AsioOutput(config);
            _effectChain = new EffectChain();
        }

        public void AddEffect(IAudioEffect effect)
        {
            _effectChain.AddEffect(effect);
        }
        Clipper2 clipper = new core.effects.distortion.Clipper2();
        Delay delay = new core.effects.delay_reeverb.Delay(500);

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

        public float SetInVol(float vol) { return volume = vol * 2f; }
        public float SetOutVol(float vol) { return involume = vol * 2f; }
        public float SetMix(float mix) { return this.mix = mix; }

        #endregion
        public void Start()
        {
            _asioOutput.Init();
            DistortionNeonPedal form = new();
            _effectChain.AddEffect(clipper);
            _effectChain.AddEffect(delay);
            _asioInput.AudioAvailable += (s, buffer) =>
            {
                for (int i = 0; i < buffer.Length; i++)
                    buffer[i] *= involume;
                // До обработки: сохраним копию "сухого" сигнала
                float[] dryBuffer = buffer.ToArray();

                // Пропорциональное применение эффектов
                int processedSamples = (int)(buffer.Length * processFraction); // processFraction от 0.0 до 1.0
                if (processedSamples > 0)
                {
                    _effectChain.Process(buffer, 0, processedSamples);
                }

                // Если нужно, дополнительно обработать остаток буфера без эффектов
                if (processedSamples < buffer.Length)
                {
                    // Копируем сухой сигнал обратно в необработанную часть
                    Array.Copy(dryBuffer, processedSamples, buffer, processedSamples, buffer.Length - processedSamples);
                }

                // Теперь миксуем dry и wet сигналы
                for (int i = 0; i < buffer.Length; i++)
                {
                    buffer[i] = dryBuffer[i] * (1f - mix) + buffer[i] * mix;
                }

                // Применяем громкость после эффектов
                for (int i = 0; i < buffer.Length; i++)
                    buffer[i] *= volume;

                var stereoBuffer = MonoToStereo(buffer);
                _asioOutput.Write(stereoBuffer);
                sender.SendBuffer(FloatToPcm16Bytes(stereoBuffer));

                lock (_bufferLock)
                {
                    _lastBuffer = buffer.ToArray(); // сохраняем только float[]
                }
            };


            _asioInput.Start();
        }

        private float[] _lastBuffer = Array.Empty<float>();
        private readonly object _bufferLock = new();

        public float[] GetLatestBuffer()
        {
            lock (_bufferLock)
            {
                return _lastBuffer.ToArray(); // возвращаем копию
            }
        }

        public void Stop()
        {
            _asioInput.Stop();
            _asioOutput.Stop();
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
            Stop();
        }
    }
}
