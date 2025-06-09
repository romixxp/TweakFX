using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TweakFX.core
{
    using NAudio.Wave;
    using System;

    public class AsioInput
    { 
        //private readonly AsioConfig _config;
        private AsioOut _asioOut;
        public event EventHandler<float[]> AudioAvailable;
        private EventHandler<AsioAudioAvailableEventArgs> _handler;
        public AsioInput()
        {

        }

        public void Start()
        {
            _asioOut = new AsioOut(_cvars.ASIO_name);
            _asioOut.InitRecordAndPlayback(null, 1, TweakFX.core._cvars.ASIO_samplerate);

            _handler = (s, e) =>
            {
                var buffer = new float[e.SamplesPerBuffer];
                e.GetAsInterleavedSamples(buffer);
                AudioAvailable?.Invoke(this, buffer);
            }; 
            _asioOut.AudioAvailable -= _handler;
            _asioOut.AudioAvailable += _handler;

            _asioOut.Play();

        }

        public void ShowControlPanel()
        {
            var asioOut = new AsioOut(TweakFX.core._cvars.ASIO_name);
            asioOut.ShowControlPanel(); 
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
