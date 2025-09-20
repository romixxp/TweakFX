using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    
namespace TweakFX.core.effects.dynamics
{
    public class Compressor : IAudioEffect
    {
        private float _threshold;     
        private float _ratio;         
        private float _attack;       
        private float _release;     
        private float _makeupGain;  
  
        private float _currentGain; 
        private float _lastGain;    
        private float _gainChangeSpeed;

        public Compressor(float threshold, float ratio, float attack, float release, float makeupGain)
        {
            _threshold = threshold;
            _ratio = ratio;
            _attack = attack;
            _release = release;
            _makeupGain = makeupGain;
  
            _currentGain = 1.0f;
            _lastGain = 1.0f;

            _gainChangeSpeed = attack / release;
        }
        
        public void UpdateThres(float val) => _threshold = val;
        public void UpdateRatio(float val) => _ratio = val;
        public void UpdateAttack(float val) => _attack = val;
        public void UpdateRelease(float val) => _release = val;
        public void UpdateMakeUp(float val) => _makeupGain = val;
        
        public void Process(float[] buffer, int offset, int count)
        {
            for (int i = offset; i < offset + count; i++)
            {
                float sample = buffer[i];
  
                if (Math.Abs(sample) > _threshold)
                {
                    float gainReduction = 1.0f / _ratio;  
                    sample = Math.Sign(sample) * (_threshold + (Math.Abs(sample) - _threshold) * gainReduction);
                }
                if (Math.Abs(sample) > _threshold)
                {
                    _currentGain = Math.Lerp(_lastGain, 0.0f, _gainChangeSpeed);
                }
                else
                {
                  _currentGain = Math.Lerp(_lastGain, 1.0f, _gainChangeSpeed);
                }
                buffer[i] = sample * _currentGain;
                _lastGain = _currentGain;
                buffer[i] *= _makeupGain;
            }
        }
    }
} 
