using System;
using System.Diagnostics;
using System.Threading.Tasks;
using NAudio.Wave;

namespace TweakFX.core
{
    public class AsioOutput
    {
        private AsioOut _asioOut;
        private BufferedWaveProvider _bufferedWaveProvider;
        private float volume = 1f;

        private EventHandler _handler;
        private int stopRetryCount = 0;

        public AsioOutput() { }

        public void Init(int samplerate)
        {
            _bufferedWaveProvider = null;
            GC.Collect(); GC.WaitForPendingFinalizers();

            Debug.WriteLine("samplerate: " + samplerate);
            _asioOut = new AsioOut(TweakFX.core._cvars.ASIO_name);

            var format = WaveFormat.CreateIeeeFloatWaveFormat(samplerate, 2); // stereo float
            _bufferedWaveProvider = new BufferedWaveProvider(format)
            {
                DiscardOnBufferOverflow = true
            };

            _asioOut.Init(_bufferedWaveProvider);
            _asioOut.Play();

            _handler = async (s, e) =>
            {
                Debug.WriteLine("asio reset request");
                await Task.Delay(300);
                await Program.engine.Stop();
                await Task.Delay(100);
                double sampleRate = await AsioUtils.GetAsioSampleRateStaAsync(TweakFX.core._cvars.ASIO_name);
                Debug.WriteLine($"ASIO sample rate reset to {sampleRate}");
                TweakFX.core._cvars.ASIO_samplerate = (int)sampleRate;
                _bufferedWaveProvider?.ClearBuffer();
                await Program.engine.Start(TweakFX.core._cvars.ASIO_samplerate);
            };

            _asioOut.DriverResetRequest -= _handler;
            _asioOut.DriverResetRequest += _handler;
        }

        public float SetVolume(float vol) => volume = Math.Clamp(vol, 0f, 1f);

        /// <summary>
        /// Принимает СТЕРЕО-буфер (float[], L-R interleaved)
        /// </summary>
        public void Write(float[] stereoBuffer)
        {
            for (int i = 0; i < stereoBuffer.Length; i++)
                stereoBuffer[i] *= volume;

            byte[] byteBuffer = new byte[stereoBuffer.Length * 4];
            Buffer.BlockCopy(stereoBuffer, 0, byteBuffer, 0, byteBuffer.Length);
            _bufferedWaveProvider.AddSamples(byteBuffer, 0, byteBuffer.Length);
        }

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