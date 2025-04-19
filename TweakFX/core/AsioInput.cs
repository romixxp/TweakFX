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
        private readonly AsioConfig _config;
        private AsioOut _asioOut;
        public event EventHandler<float[]> AudioAvailable;

        public AsioInput(AsioConfig config)
        {
            _config = config;
        }
        public AsioInput()
        {

        }

        public void Start()
        {
            _asioOut = new AsioOut(_config.DriverName);
            _asioOut.InitRecordAndPlayback(null, 1, _config.SampleRate);

            _asioOut.AudioAvailable += (s, e) =>
            {
                var buffer = new float[e.SamplesPerBuffer];
                e.GetAsInterleavedSamples(buffer);
                AudioAvailable?.Invoke(this, buffer);
            };

            _asioOut.Play();

        }

        public void ShowControlPanel()
        {
            var asioOut = new AsioOut("Focusrite USB ASIO"); // или выбрать по имени из AsioOut.GetDriverNames()
            asioOut.ShowControlPanel(); // ← Открывает ASIO панель
        }
        public void Stop() => _asioOut?.Stop();
    }
}
