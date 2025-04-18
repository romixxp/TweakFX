using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TweakFX.core
{
    using NAudio.Wave;
    using NAudio.Wave.Asio;

    public class AsioOutput
    {
        private AsioOut _asioOut;
        private BufferedWaveProvider _bufferedWaveProvider;
        private AudioConfig _config;

        public AsioOutput(AudioConfig config)
        {
            _config = config;
            Initialize();
        }

        private void Initialize()
        {
            _asioOut = new AsioOut(_config.AsioDriverName);
            _asioOut.InitRecordAndPlayback(null, _config.OutputChannels, _config.SampleRate);

            _bufferedWaveProvider = new BufferedWaveProvider(
                new WaveFormat(_config.SampleRate, 16, _config.OutputChannels)
            );

            _asioOut.Init(_bufferedWaveProvider);
            _asioOut.Play();
        }

        public void Send(byte[] buffer, int count)
        {
            _bufferedWaveProvider.AddSamples(buffer, 0, count);
        }

        public void Stop()
        {
            _asioOut?.Stop();
            _asioOut?.Dispose();
        }

        public void Restart()
        {
            Stop();
            Initialize();
        }
    }

}
