using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TweakFX.core
{
    using System.Diagnostics;
    using NAudio.Wave;

    public class AsioOutput
    {
        //private readonly AsioConfig _config;
        private AsioOut _asioOut;
        private BufferedWaveProvider _bufferedWaveProvider;
        private float volume = 1f;
        public AsioOutput()
        {
            //_config = config;
        }
        private EventHandler _handler;
        public void Init(int samplerate)
        {

            _bufferedWaveProvider = null; 
            GC.Collect(); GC.WaitForPendingFinalizers(); 

            Debug.WriteLine("samplerate: " + samplerate);
            _asioOut = new AsioOut(TweakFX.core._cvars.ASIO_name);

            WaveFormat format = WaveFormat.CreateIeeeFloatWaveFormat(samplerate, 2);
            _bufferedWaveProvider = new BufferedWaveProvider(format);
            _asioOut.Init(_bufferedWaveProvider);
            _asioOut.Play();

            _handler = async (s, e) => 
            {
                Debug.WriteLine("asio reset request");
                await Task.Delay(300);
                Program.engine.Stop().Wait();
                await Task.Delay(100);
                double sampleRate = await AsioUtils.GetAsioSampleRateStaAsync(TweakFX.core._cvars.ASIO_name);
                Debug.WriteLine(samplerate);
                TweakFX.core._cvars.ASIO_samplerate = (int)sampleRate;
                _bufferedWaveProvider?.ClearBuffer();
                Program.engine.Start(TweakFX.core._cvars.ASIO_samplerate);
            };
            _asioOut.DriverResetRequest -= _handler;
            _asioOut.DriverResetRequest += _handler;
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
        private int stopRetryCount = 0;
        public async Task Stop()
        {
            const int maxRetries = 10;
            const int retryDelayMs = 50;

            while (stopRetryCount < maxRetries)
            {
                try
                {
                    _asioOut?.Stop();
                    _asioOut?.Dispose();
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    //MessageBox.Show("ASIO Output stopped successfully.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                }
                catch (System.Runtime.InteropServices.SEHException)
                {
                    stopRetryCount++;
                    await Task.Delay(retryDelayMs);
                }
            }
            stopRetryCount = 0;
        }


    }
}
