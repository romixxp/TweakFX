using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TweakFX.core
{
    public interface IAudioEffect
    {
        byte[] Process(byte[] buffer, int bytesRecorded);
    }
}
