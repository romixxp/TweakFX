using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;
using NAudio.Wave.Asio;

namespace TweakFX.core
{
    public class AsioUtils
    {
        public static double GetAsioSampleRateSync(string driverName)
        {
            double sampleRate = 0;
            AsioDriver asioDriver = null;

            try
            {
                asioDriver = AsioDriver.GetAsioDriverByName(driverName);
                asioDriver.Init(IntPtr.Zero);
                sampleRate = asioDriver.GetSampleRate();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Ошибка при работе с ASIO-драйвером: {ex.Message}");
            }
            finally
            {
                if (asioDriver != null)
                {
                    try
                    {
                        asioDriver.ReleaseComAsioDriver();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"Ошибка при освобождении ASIO-драйвера: {ex.Message}");
                    }
                }
            }

            return sampleRate;
        }



        public static Task<double> GetAsioSampleRateStaAsync(string driverName)
        {
            var tcs = new TaskCompletionSource<double>();

            Thread staThread = new Thread(() =>
            {
                try
                {
                    double result = GetAsioSampleRateSync(driverName);
                    tcs.SetResult(result);
                }
                catch (Exception ex)
                {
                    tcs.SetException(ex);
                }
            });

            staThread.SetApartmentState(ApartmentState.STA);
            staThread.Start();

            return tcs.Task;
        }


        public static void SetAsioSampleRateViaInit(string driverName, int sampleRate)
        {
            AsioOut asioOut = null;
            try
            {
                asioOut = new AsioOut(driverName);

                asioOut.InitRecordAndPlayback(null, 1, sampleRate);
                asioOut.Stop();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Ошибка при установке sample rate через инициализацию ASIO: {ex.Message}");
            }
            finally
            {
                if (asioOut != null)
                {
                    asioOut.Dispose();
                }
            }
        }

    }
}
