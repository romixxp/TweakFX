using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TweakFX.core.mics
{
    class SquareWaveGenerator
    {
        private double _phase = 0.0;
        private readonly double _sampleRate;
        private double _frequency;
        private double _durationSeconds;
        private double _elapsedSamples;

        public bool IsPlaying { get; private set; } = false;

        public SquareWaveGenerator(double sampleRate, double frequency, double durationSeconds = 2.0)
        {
            _sampleRate = sampleRate;
            _frequency = frequency;
            _durationSeconds = durationSeconds;
        }

        public void Start()
        {
            _elapsedSamples = 0;
            _phase = 0;
            IsPlaying = true;
        }

        public void Stop()
        {
            IsPlaying = false;
        }

        public void SetFrequency(double frequency)
        {
            _frequency = frequency;
        }

        public void FillBuffer(float[] buffer)
        {
            if (!IsPlaying)
            {
                Array.Fill(buffer, 0f); // тишина
                return;
            }

            double totalSamples = _durationSeconds * _sampleRate;
            double phaseIncrement = _frequency / _sampleRate;

            for (int i = 0; i < buffer.Length; i++)
            {
                if (_elapsedSamples >= totalSamples)
                {
                    buffer[i] = 0f;
                    IsPlaying = false; // автоостановка
                    continue;
                }

                buffer[i] = (_phase < 0.5) ? 1.0f : -1.0f;

                _phase += phaseIncrement;
                if (_phase >= 1.0)
                    _phase -= 1.0;

                _elapsedSamples++;
            }
        }
    }


}
