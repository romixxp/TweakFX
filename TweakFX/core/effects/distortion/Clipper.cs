using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TweakFX.core.effects.distortion
{
    public class Clipper : IAudioEffect
    {
        private float _distortionAmount;
        private float _tone; 
        private float _volume; 

        public Clipper(float distortionAmount = 1.0f, float tone = 0.5f, float volume = 1.0f)
        {
            _distortionAmount = distortionAmount;
            _tone = tone;
            _volume = volume;
        }
        public void UpdateDistortionAmount(float newDistortionAmount)
        {
            _distortionAmount = newDistortionAmount;
        }

        public void UpdateTone(float newTone)
        {
            _tone = newTone;
        }
        public void UpdateVolume(float newVolume)
        {
            _volume = newVolume;
        }

        public void Process(float[] buffer, int offset, int count)
        {
            for (int i = offset; i < offset + count; i++)
            {
                buffer[i] *= _distortionAmount;
                buffer[i] = ApplyTone(buffer[i]);
                buffer[i] *= _volume;
            }
        }

        private float ApplyTone(float sample)
        {

            if (_tone < 0.5f)
            {
                return sample * (1.0f - (0.5f - _tone) * 2.0f);
            }
            else
            {
                return sample * (1.0f + (_tone - 0.5f) * 2.0f); 
            }
        }
    }
}
