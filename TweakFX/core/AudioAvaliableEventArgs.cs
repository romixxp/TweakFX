using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TweakFX.core
{
    using System;

    public class AudioAvailableEventArgs : EventArgs
    {
        public byte[] Buffer { get; }
        public int BytesRecorded { get; }

        public AudioAvailableEventArgs(byte[] buffer, int bytesRecorded)
        {
            Buffer = buffer;
            BytesRecorded = bytesRecorded;
        }
    }
}
