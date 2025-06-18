using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TweakFX.core.effects.eq
{
    public class EqualizerBand
    {
        public float Frequency { get; set; }
        public float Gain { get; set; }
        public float Bandwidth { get; set; }
        public FilterType FilterType { get; set; }
    }
}
