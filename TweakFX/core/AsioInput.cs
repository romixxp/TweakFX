using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TweakFX.core
{
    using NAudio.Wave;
    using NAudio.Wave.Asio;

    public class AsioInput
    {
        private AsioOut _asio;
        private AudioConfig _config;

        public event EventHandler<AudioAvailableEventArgs> OnAudioAvailable;

        public AsioInput(AudioConfig config)
        {
            _config = config;
            Initialize();
        }

        private void Initialize()
        {
            _asio = new AsioOut(_config.AsioDriverName);
            _asio.InitRecordAndPlayback(null, _config.OutputChannels, _config.SampleRate);
            _asio.AudioAvailable += Asio_AudioAvailable;
        }

        private void Asio_AudioAvailable(object sender, AsioAudioAvailableEventArgs e)
        {
            int channels = _config.OutputChannels;
            int samples = e.SamplesPerBuffer * channels;
            float[] floatBuffer = new float[samples];
            e.GetAsInterleavedSamples(floatBuffer);

            byte[] byteBuffer = new byte[samples * 2]; // 16 бит = 2 байта

            for (int i = 0; i < samples; i++)
            {
                short sample = (short)(Math.Max(Math.Min(floatBuffer[i], 1.0f), -1.0f) * 32767.0f);
                byteBuffer[i * 2] = (byte)(sample & 0xFF);
                byteBuffer[i * 2 + 1] = (byte)((sample >> 8) & 0xFF);
            }

            OnAudioAvailable?.Invoke(this, new AudioAvailableEventArgs(byteBuffer, byteBuffer.Length));

            e.WrittenToOutputBuffers = true;
        }


        public void Start() => _asio.Play();

        public void Stop()
        {
            _asio?.Stop();
            _asio?.Dispose();
        }

        public void Restart()
        {
            Stop();
            Initialize();
            Start();
        }
    }
}
