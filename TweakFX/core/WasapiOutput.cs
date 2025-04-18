using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TweakFX.core
{
    using NAudio.Wave;

    public class WasapiOutput
    {
        private WaveOutEvent _waveOut;
        private BufferedWaveProvider _bufferedWaveProvider;

        public WasapiOutput()
        {
            _waveOut = new WaveOutEvent();
            _bufferedWaveProvider = new BufferedWaveProvider(new WaveFormat(44100, 16, 2));
            _waveOut.Init(_bufferedWaveProvider);
            _waveOut.Play();
        }

        public void Send(byte[] buffer, int count)
        {
            _bufferedWaveProvider.AddSamples(buffer, 0, count);
        }
    }

}
