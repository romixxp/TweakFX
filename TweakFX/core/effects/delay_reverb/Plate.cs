using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TweakFX.core.effects.delay_reverb
{
    public class Plate : IAudioEffect
    {
        private float[] _combBuffer;
        private float[] _allPassBuffer;
        private int _combIndex;
        private int _allPassIndex;

        private int _combDelayInSamples;
        private int _allPassDelayInSamples;

        private float _combFeedback;
        private float _allPassFeedback;
        private float _wetMix;
        private float _dryMix;

        public Plate(
            int combDelayMs = 50,
            float combFeedback = 0.7f,
            int allPassDelayMs = 10,
            float allPassFeedback = 0.5f,
            float wetMix = 0.5f,
            float dryMix = 0.5f,
            int sampleRate = 44100)
        {
            _combDelayInSamples = Math.Max(1, (int)(combDelayMs * (sampleRate / 1000.0f)));
            _allPassDelayInSamples = Math.Max(1, (int)(allPassDelayMs * (sampleRate / 1000.0f)));

            _combBuffer = new float[_combDelayInSamples];
            _allPassBuffer = new float[_allPassDelayInSamples];

            _combIndex = 0;
            _allPassIndex = 0;

            _combFeedback = combFeedback;
            _allPassFeedback = allPassFeedback;
            _wetMix = wetMix;
            _dryMix = dryMix;
        }

        public void UpdateCombDelay(int combDelayMs, int sampleRate = 44100)
        {
            _combDelayInSamples = Math.Max(1, (int)(combDelayMs * (sampleRate / 1000.0f)));
            _combBuffer = new float[_combDelayInSamples];
            _combIndex = 0;
        }

        public void UpdateAllPassDelay(int allPassDelayMs, int sampleRate = 44100)
        {
            _allPassDelayInSamples = Math.Max(1, (int)(allPassDelayMs * (sampleRate / 1000.0f)));
            _allPassBuffer = new float[_allPassDelayInSamples];
            _allPassIndex = 0;
        }

        public void UpdateCombFeedback(float feedback)
        {
            _combFeedback = feedback;
        }

        public void UpdateAllPassFeedback(float feedback)
        {
            _allPassFeedback = feedback;
        }

        public void UpdateWetMix(float wetMix)
        {
            _wetMix = wetMix;
        }

        public void UpdateDryMix(float dryMix)
        {
            _dryMix = dryMix;
        }

        public void Process(float[] buffer, int offset, int count)
        {
            for (int i = offset; i < offset + count; i++)
            {
                float input = buffer[i];

                // Comb filter
                float combOutput = _combBuffer[_combIndex];
                _combBuffer[_combIndex] = input + combOutput * _combFeedback;
                _combIndex = (_combIndex + 1) % _combDelayInSamples;

                // All-pass filter
                float allPassOutput = _allPassBuffer[_allPassIndex];
                float temp = combOutput + allPassOutput * _allPassFeedback;
                _allPassBuffer[_allPassIndex] = temp;
                float filteredOutput = -temp * _allPassFeedback + allPassOutput;
                _allPassIndex = (_allPassIndex + 1) % _allPassDelayInSamples;

                // Mix dry/wet
                buffer[i] = input * _dryMix + filteredOutput * _wetMix;
            }
        }
    }
}