using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TweakFX.core.effects.delay_reverb
{
    public class Delay : IAudioEffect
    {
        private float[] _delayBuffer; 
        private int _delayTimeInSamples; 
        private int _writeIndex;  
        private float _feedback;  
        private float _wetMix;  
        private float _dryMix;  

        public Delay(int delayTimeInMs = 300, float feedback = 0.5f, float wetMix = 0.5f, float dryMix = 0.5f, int sampleRate = 44100)
        {
            _delayTimeInSamples = (int)(delayTimeInMs * (sampleRate / 1000.0f));  
            _delayBuffer = new float[_delayTimeInSamples];
            _writeIndex = 0;
            _feedback = feedback;
            _wetMix = wetMix;
            _dryMix = dryMix;
        }

        public void UpdateDelayTime(int delayTimeInMs, int sampleRate = 44100)
        {
            _delayTimeInSamples = Math.Max(1, (int)(delayTimeInMs * (sampleRate / 1000.0f)));  
            _delayBuffer = new float[_delayTimeInSamples];
            _writeIndex = 0;
        }

        public void UpdateFeedback(float feedback) => _feedback = feedback;
        public void UpdateWetMix(float wetMix) => _wetMix = wetMix;
        public void UpdateDryMix(float dryMix) => _dryMix = dryMix;

        public void Process(float[] buffer, int offset, int count)
        {
            for (int i = offset; i < offset + count; i++)
            {
                float currentSample = buffer[i];
                float delayedSample = _delayBuffer[_writeIndex];
                _delayBuffer[_writeIndex] = currentSample + delayedSample * _feedback;
                buffer[i] = currentSample * _dryMix + delayedSample * _wetMix;
                _writeIndex = (_writeIndex + 1) % _delayTimeInSamples;
            }
        }
    }
}
