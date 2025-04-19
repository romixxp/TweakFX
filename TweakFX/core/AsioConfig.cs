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

    public class AsioConfig
    {
        public string DriverName { get; set; } = "Focusrite USB ASIO";
        public int InputChannel { get; set; } = 0;
        public int OutputChannel { get; set; } = 0;
        public int SampleRate { get; set; } = 44100;
        public int BufferSize { get; set; } = 128;
    }

}
