using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TweakFX.core
{
    public class ColorPalette
    {
        public Color BackgroundTop { get; set; }
        public Color BackgroundBottom { get; set; }
        public Color PotBase { get; set; }
        public Color[] PotGradient { get; set; }
        public Func<float, Color> MarkerColor { get; set; }

    }
}
