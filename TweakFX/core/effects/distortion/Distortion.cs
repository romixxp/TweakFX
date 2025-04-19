using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TweakFX.core.effects.distortion
{
    public class Distortion : IAudioEffect
    {
        private readonly float _threshold;
        private readonly float _amount;

        public Distortion(float threshold = 0.5f, float amount = 1.5f)
        {
            _threshold = threshold;
            _amount = amount;
        }

        public void Process(float[] buffer, int offset, int count)
        {
            for (int i = offset; i < offset + count; i++)
            {
                if (Math.Abs(buffer[i]) > _threshold)
                {
                    buffer[i] = Math.Sign(buffer[i]) * _threshold * _amount;
                }
            }
        }
    }
}
