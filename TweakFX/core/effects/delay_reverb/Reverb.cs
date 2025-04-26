using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TweakFX.core.effects.delay_reverb
{
    public class Reverb : IAudioEffect
    {
        private const int NumCombs = 6;
        private const int NumAllPasses = 4;

        private float[][] _combBuffers;
        private int[] _combIndices;
        private int[] _combDelays;
        private float[] _combFeedbacks;

        private float[][] _allPassBuffers;
        private int[] _allPassIndices;
        private int[] _allPassDelays;

        private float _allPassFeedback = 0.5f;
        private float _wetMix;
        private float _dryMix;
        private float _damping;
        private float _preDelay;
        private int _sampleRate;
        private float[] _combLowpassState;

        private float[] _preDelayBuffer;
        private int _preDelaySamples;
        private int _preDelayIndex;

        public Reverb(
            float decayMs = 1500f,
            float damping = 0.3f,
            float preDelayMs = 20f,
            float wetMix = 0.5f,
            float dryMix = 0.5f,
            int sampleRate = 44100)
        {
            _sampleRate = sampleRate;
            _wetMix = wetMix;
            _dryMix = dryMix;
            _damping = Math.Clamp(damping, 0f, 1f);
            _preDelay = preDelayMs;

            // Comb filters
            _combBuffers = new float[NumCombs][];
            _combIndices = new int[NumCombs];
            _combDelays = new int[NumCombs];
            _combFeedbacks = new float[NumCombs];
            _combLowpassState = new float[NumCombs];

            // Примерные задержки comb-фильтров (мс)
            int[] combDelayMs = { 29, 37, 41, 43, 47, 53 };

            for (int i = 0; i < NumCombs; i++)
            {
                _combDelays[i] = Math.Max(1, (int)(combDelayMs[i] * sampleRate / 1000.0));
                _combBuffers[i] = new float[_combDelays[i]];
                _combFeedbacks[i] = DecayToFeedback(decayMs, _combDelays[i], sampleRate);
                _combIndices[i] = 0;
            }

            // All-pass filters
            _allPassBuffers = new float[NumAllPasses][];
            _allPassIndices = new int[NumAllPasses];
            _allPassDelays = new int[] {
            (int)(5 * sampleRate / 1000.0),
            (int)(1.7f * sampleRate / 1000.0),
            (int)(6.1f * sampleRate / 1000.0),
            (int)(7.3f * sampleRate / 1000.0)
        };

            for (int i = 0; i < NumAllPasses; i++)
            {
                _allPassBuffers[i] = new float[_allPassDelays[i]];
                _allPassIndices[i] = 0;
            }

            // Pre-delay
            _preDelaySamples = Math.Max(0, (int)(_preDelay * sampleRate / 1000.0f));
            _preDelayBuffer = new float[_preDelaySamples + 1];
            _preDelayIndex = 0;
        }

        public void SetDryWetMix(float wetMix, float dryMix)
        {
            _wetMix = Math.Clamp(wetMix, 0f, 1f);
            _dryMix = Math.Clamp(dryMix, 0f, 1f);
        }

        public void SetDamping(float damping)
        {
            _damping = Math.Clamp(damping, 0f, 1f);
        }

        public void SetPreDelay(float preDelayMs)
        {
            _preDelay = Math.Max(0f, preDelayMs);
            int newPreDelaySamples = Math.Max(0, (int)(_preDelay * _sampleRate / 1000.0f));
            if (newPreDelaySamples != _preDelaySamples)
            {
                _preDelaySamples = newPreDelaySamples;
                _preDelayBuffer = new float[_preDelaySamples + 1];
                _preDelayIndex = 0;
            }
        }

        public void SetDecay(float decayMs)
        {
            decayMs = Math.Max(1f, decayMs); // минимальное значение, чтобы избежать деления на ноль
            for (int i = 0; i < NumCombs; i++)
            {
                _combFeedbacks[i] = DecayToFeedback(decayMs, _combDelays[i], _sampleRate);
            }
        }

        public void SetAllPassFeedback(float feedback)
        {
            _allPassFeedback = Math.Clamp(feedback, 0f, 1f);
        }

        private float DecayToFeedback(float decayMs, int delaySamples, int sampleRate)
        {
            float delayTimeSec = delaySamples / (float)sampleRate;
            float decayTimeSec = decayMs / 1000f;
            return (float)Math.Pow(10.0, (-3.0 * delayTimeSec / decayTimeSec)); // -60 dB decay
        }

        public void Process(float[] buffer, int offset, int count)
        {
            for (int i = offset; i < offset + count; i++)
            {
                float input = buffer[i];

                // Pre-delay
                float preDelayed = _preDelayBuffer[_preDelayIndex];
                _preDelayBuffer[_preDelayIndex] = input;
                _preDelayIndex = (_preDelayIndex + 1) % _preDelayBuffer.Length;

                float combSum = 0f;

                for (int j = 0; j < NumCombs; j++)
                {
                    float[] combBuf = _combBuffers[j];
                    int combIdx = _combIndices[j];

                    float delayed = combBuf[combIdx];
                    _combLowpassState[j] = (1 - _damping) * delayed + _damping * _combLowpassState[j];

                    combBuf[combIdx] = preDelayed + _combLowpassState[j] * _combFeedbacks[j];
                    _combIndices[j] = (combIdx + 1) % _combDelays[j];

                    combSum += delayed;
                }

                float allPassOut = combSum;
                for (int j = 0; j < NumAllPasses; j++)
                {
                    float[] apBuf = _allPassBuffers[j];
                    int apIdx = _allPassIndices[j];

                    float bufOut = apBuf[apIdx];
                    float temp = allPassOut + bufOut * _allPassFeedback;
                    apBuf[apIdx] = temp;
                    allPassOut = -temp * _allPassFeedback + bufOut;

                    _allPassIndices[j] = (apIdx + 1) % _allPassDelays[j];
                }

                buffer[i] = _dryMix * input + _wetMix * allPassOut;
            }
        }

    }

}
