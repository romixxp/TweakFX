using System;

namespace TweakFX.core.effects.pitch
{
    public class PitchShifter : IAudioEffect
    {
        private readonly int _sampleRate;
        private float[] _inputBuffer;
        private int _inputBufferSize;
        private int _inputWritePos;

        private float _grainSizeInSamples;
        private float _overlap;
        private float _pitchShift;
        private float _mix;

        private float[] _window;

        private float _readHead;

        public PitchShifter(float pitchShift = 1.0f, int grainSizeMs = 50, int sampleRate = 44100, float mix = 1.0f)
        {
            _sampleRate = sampleRate;
            _pitchShift = pitchShift;
            _mix = Math.Clamp(mix, 0f, 1f);

            SetGrainSize(grainSizeMs);
        }

        public void SetGrainSize(int grainSizeMs)
        {
            _grainSizeInSamples = _sampleRate * grainSizeMs / 1000f;
            _overlap = 0.5f;

            _inputBufferSize = (int)(_grainSizeInSamples * 4);
            _inputBuffer = new float[_inputBufferSize];
            _inputWritePos = 0;

            _readHead = 0;

            GenerateWindow();
        }

        public void SetPitchShift(float pitchShift)
        {
            _pitchShift = pitchShift;
        }

        public float Mix
        {
            get => _mix;
            set => _mix = Math.Clamp(value, 0f, 1f);
        }

        private void GenerateWindow()
        {
            int size = (int)_grainSizeInSamples;
            _window = new float[size];
            for (int i = 0; i < size; i++)
            {
                _window[i] = 0.5f * (1f - (float)Math.Cos(2.0 * Math.PI * i / (size - 1)));
            }
        }

        public void Process(float[] buffer, int offset, int count)
        {
            for (int i = offset; i < offset + count; i++)
            {
                float inputSample = buffer[i];

                _inputBuffer[_inputWritePos] = inputSample;
                _inputWritePos = (_inputWritePos + 1) % _inputBufferSize;

                float outputSample = 0f;

                // Read current grain windowed
                outputSample += ReadGrain(_readHead);

                // Read overlapped grain (half grainSize offset)
                float overlappedHead = (_readHead + _grainSizeInSamples * _overlap) % _inputBufferSize;
                outputSample += ReadGrain(overlappedHead);

                outputSample *= 0.5f; // Average the two overlapped grains

                buffer[i] = inputSample * (1f - _mix) + outputSample * _mix;

                _readHead += _pitchShift;
                if (_readHead >= _inputBufferSize) _readHead -= _inputBufferSize;
            }
        }

        private float ReadGrain(float pos)
        {
            int basePos = (int)pos;
            int nextPos = (basePos + 1) % _inputBufferSize;
            float frac = pos - basePos;

            float sample = (1f - frac) * _inputBuffer[basePos] + frac * _inputBuffer[nextPos];

            int grainIndex = (int)(pos % _grainSizeInSamples);
            if (grainIndex < 0 || grainIndex >= _window.Length) return 0f;

            return sample * _window[grainIndex];
        }
    }
}
