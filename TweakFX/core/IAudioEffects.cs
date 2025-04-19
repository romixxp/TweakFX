using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TweakFX.core
{
    public interface IAudioEffect
    {
        void Process(float[] buffer, int offset, int count);
    }
}
