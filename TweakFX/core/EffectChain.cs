using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TweakFX.core
{
    using System.Collections.Generic;

    public class EffectChain
    {
        private readonly List<IAudioEffect> _effects = new();

        public void AddEffect(IAudioEffect effect)
        {
            _effects.Add(effect);
        }

        public void Process(float[] buffer, int offset, int count)
        {
            foreach (var effect in _effects)
            {
                effect.Process(buffer, offset, count);
            }
        }
        public void Clear()
        {
            _effects.Clear();
        }
    }
}

