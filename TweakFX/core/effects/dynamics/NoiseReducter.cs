using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TweakFX.core.effects.dynamics
{
    public class NoiseReducer : IAudioEffect
    {
        private float _threshold;
        private float _reductionAmount;
        private float _attack;
        private float _release;
        private float _gainSmooth;

        private float _envelope;

        public NoiseReducer(float threshold = 0.02f, float reductionAmount = 0.5f, float attack = 0.01f, float release = 0.1f, int sampleRate = 44100)
        {
            _threshold = threshold;
            _reductionAmount = reductionAmount;
            _attack = attack;
            _release = release;
            _gainSmooth = 1.0f;

            float attackCoef = (float)Math.Exp(-1.0 / (attack * sampleRate));
            float releaseCoef = (float)Math.Exp(-1.0 / (release * sampleRate));

            _envelope = 0.0f;
        }

        public void UpdateThreshold(float threshold)
        {
            _threshold = threshold;
        }

        public void UpdateReductionAmount(float reductionAmount)
        {
            _reductionAmount = reductionAmount;
        }

        public void UpdateAttack(float attack, int sampleRate = 44100)
        {
            _attack = attack;
        }

        public void UpdateRelease(float release, int sampleRate = 44100)
        {
            _release = release;
        }

        public void Process(float[] buffer, int offset, int count)
        {
            float attackCoef = (float)Math.Exp(-1.0 / (_attack * 44100));
            float releaseCoef = (float)Math.Exp(-1.0 / (_release * 44100));

            for (int i = offset; i < offset + count; i++)
            {
                float input = Math.Abs(buffer[i]);

                if (input > _envelope)
                    _envelope = attackCoef * (_envelope - input) + input;
                else
                    _envelope = releaseCoef * (_envelope - input) + input;

                float gain = (_envelope < _threshold) ? _reductionAmount : 1.0f;
                buffer[i] *= gain;
            }
        }
    }
} 
