using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TweakFX.core.effects.distortion
{
    public class Clipper2 : IAudioEffect
    {
        private float _distortionAmount; 
        private float _tone; 
        private float _threshold;
        private float _volume; 

        public Clipper2(float threshold = 0.3f, float distortionAmount = 5.0f, float tone = 0.1f, float volume = 1.0f)
        {
            _distortionAmount = distortionAmount;
            _tone = 0.1f;
            _volume = volume;
            _threshold = threshold;
        }
        public void UpdateDistortionAmount(float newDistortionAmount)
        {
            if (newDistortionAmount > 0.5f)
                _distortionAmount = newDistortionAmount;
            else
                _distortionAmount = 0.5f;
        }

        public void UpdateTone(float newTone)
        {
            _tone = newTone;
        }
        public void UpdateThreshold(float newThreshold)
        {
            _threshold = newThreshold;
        }

        public void UpdateVolume(float newVolume)
        {
            _volume = newVolume;
        }

        public void Process(float[] buffer, int offset, int count)
        {
            for (int i = offset; i < offset + count; i++)
            {
                if (buffer[i] * _distortionAmount > _threshold)
                    buffer[i] = _threshold;
                else if (buffer[i] * _distortionAmount < -_threshold)
                    buffer[i] = -_threshold;
                else
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
