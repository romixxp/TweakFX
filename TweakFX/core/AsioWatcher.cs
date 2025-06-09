using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;

namespace TweakFX.core
{
    public class AsioWatcher
    {
        private AsioOut _asioOut = new AsioOut(TweakFX.core._cvars.ASIO_name);

        public AsioWatcher()
        {
            _asioOut.DriverResetRequest += async (s, e) =>
            {
                Task.Run(async () =>
                {
                    Debug.WriteLine("asio reset request");
                    await Task.Delay(300);
                    await Program.engine.Stop();
                    await Task.Delay(100);
                    int newRate = (int)await AsioUtils.GetAsioSampleRateStaAsync(_cvars.ASIO_name);
                    _cvars.ASIO_samplerate = newRate;
                    await Program.engine.Start(newRate);
                });
            };

            try
            {
                _asioOut.InitRecordAndPlayback(null, 1, TweakFX.core._cvars.ASIO_initsamplerate);
                _asioOut.Play(); 
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Ошибка запуска ASIO: {ex.Message}");
            }
        }

        public void Dispose()
        {
            _asioOut?.Stop();
            _asioOut?.Dispose();
            _asioOut = null;

            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }

}
