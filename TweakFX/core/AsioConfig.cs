using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TweakFX.core
{
    using System;
    using System.Collections.Generic;
    using NAudio.Wave;
    using NAudio.Wave.Asio;

    public class AudioConfig
    {
        public string AsioDriverName { get; set; }
        public int SampleRate { get; set; }
        public int BufferSize { get; set; }
        public int InputChannel { get; set; }
        public int OutputChannels { get; set; }

        public AudioConfig()
        {
            var drivers = GetAvailableAsioDrivers();
            AsioDriverName = drivers.Count > 0 ? drivers[0] : null;
            SampleRate = 44100;
            BufferSize = 512;
            InputChannel = 0;
            OutputChannels = 2;
        }

        public static List<string> GetAvailableAsioDrivers()
        {
            return new List<string>(AsioOut.GetDriverNames());
        }

        public override string ToString()
        {
            return $"ASIO: {AsioDriverName}, SR: {SampleRate}, Buffer: {BufferSize}, InCh: {InputChannel}, OutCh: {OutputChannels}";
        }
    }
}
