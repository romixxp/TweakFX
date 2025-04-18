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
        private readonly List<IAudioEffect> _effects = new List<IAudioEffect>();

        public void AddEffect(IAudioEffect effect)
        {
            _effects.Add(effect);
        }

        public void RemoveEffect(IAudioEffect effect)
        {
            _effects.Remove(effect);
        }

        public byte[] Process(byte[] buffer, int bytesRecorded)
        {
            byte[] processed = buffer;

            foreach (var effect in _effects)
            {
                processed = effect.Process(processed, bytesRecorded);
            }

            return processed;
        }
    }

}
