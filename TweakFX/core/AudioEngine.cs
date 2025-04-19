using System;
using NAudio.Wave;
using System.Windows.Forms;
using TweakFX; // Где лежит AsyncVirtualMicrophoneSender
using System.Threading;
using TweakFX.core.effects.distortion;
using TweakFX.ui.controls;
using dfsa.ui;

namespace TweakFX.core
{
    public class AudioEngine : IDisposable
    {
        private readonly AsioConfig _config;
        private readonly AsioInput _asioInput;
        private readonly AsioOutput _asioOutput;
        private readonly EffectChain _effectChain;
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
        Clipper2 effect = new core.effects.distortion.Clipper2();

        public void UpdDist(float newDistortionAmount)
        {
            effect.UpdateDistortionAmount(newDistortionAmount);
        }

        // Метод для обновления тона
        public void UpdTone(float newTone)
        {
            effect.UpdateTone(newTone);
        }
        public void UpdThres(float newThres)
        {
            effect.UpdateThreshold(newThres);
        }

        // Метод для обновления громкости
        public void UpdVol(float newVolume)
        {
            effect.UpdateVolume(newVolume);
        }

        public void Start()
        {
            // Добавляем эффект дисторшн

            _asioOutput.Init();
            DistortionNeonPedal form = new();
            //_effectChain.AddEffect(new core.effects.delay_reeverb.Delay(500));
            _effectChain.AddEffect(effect);
            AsioConfig asiocfg = new();
            _asioInput.AudioAvailable += (s, buffer) =>
            {
                //_effectChain.Process(buffer, 0, buffer.Length); // Применяем все эффекты
                _effectChain.Process(buffer, 0, buffer.Length);
                var stereoBuffer = MonoToStereo(buffer);
                _asioOutput.Write(stereoBuffer);
                var byteBuffer = FloatToPcm16Bytes(stereoBuffer);
                byte[] myPcmBuffer = byteBuffer; // должен быть PCM-совместим с WaveFormat
                sender.SendBuffer(myPcmBuffer);
            };

            _asioInput.Start();
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
