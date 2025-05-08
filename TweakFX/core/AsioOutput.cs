using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TweakFX.core
{
    using NAudio.Wave;

    public class AsioOutput
    {
        private readonly AsioConfig _config;
        private AsioOut _asioOut;
        private BufferedWaveProvider _bufferedWaveProvider;
        private float volume = 1f;
        public AsioOutput(AsioConfig config)
        {
            _config = config;
        }

        public void Init()
        {
            _asioOut = new AsioOut(_config.DriverName);
            WaveFormat format = WaveFormat.CreateIeeeFloatWaveFormat(_config.SampleRate, 2);
            _bufferedWaveProvider = new BufferedWaveProvider(format);
            _asioOut.Init(_bufferedWaveProvider); // только это
            _asioOut.Play();
        }
        public float SetVolume(float vol) => volume = Math.Clamp(vol, 0f, 1f);
        public void Write(float[] buffer)
        {
            for (int i = 0; i < buffer.Length; i++)
                buffer[i] *= volume;
            byte[] byteBuffer = new byte[buffer.Length * 4];
            Buffer.BlockCopy(buffer, 0, byteBuffer, 0, byteBuffer.Length);
            _bufferedWaveProvider.AddSamples(byteBuffer, 0, byteBuffer.Length);

        }

        public void Stop() => _asioOut?.Stop();
    }
}
