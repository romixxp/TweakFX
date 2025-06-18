using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Dsp;
using TweakFX.core.dsp;

namespace TweakFX.core.effects.eq
{
    public class Equalizer : IAudioEffect
    {
        private readonly List<EqualizerBand> _bands;
        private readonly BiquadFilter[] _filters;
        private float _dryWetMix = 1.0f;
        private readonly int _sampleRate;

        public Equalizer(List<EqualizerBand> bands, int sampleRate = 44100)
        {
            _sampleRate = sampleRate;
            _bands = bands;
            _filters = new BiquadFilter[bands.Count];

            RecalculateFilters();
        }

        public void UpdateBands(List<EqualizerBand> bands)
        {
            _bands.Clear();
            _bands.AddRange(bands);
            RecalculateFilters();
        }
        public void SetDryWetMix(float mix) => _dryWetMix = Math.Clamp(mix, 0f, 1f);
        private void RecalculateFilters()
        {
            for (int i = 0; i < _bands.Count; i++)
            {
                var band = _bands[i];
                switch (band.FilterType)
                {
                    case FilterType.Peaking:
                        _filters[i] = BiquadFilter.PeakingEQ(_sampleRate, band.Frequency, band.Bandwidth, band.Gain);
                        break;
                    case FilterType.LowShelf:
                        _filters[i] = BiquadFilter.LowShelf(_sampleRate, band.Frequency, band.Gain);
                        break;
                    case FilterType.HighShelf:
                        _filters[i] = BiquadFilter.HighShelf(_sampleRate, band.Frequency, band.Gain);
                        break;
                }
            }
        }


        public void Process(float[] buffer, int offset, int count)
        {
            for (int i = offset; i < offset + count; i++)
            {
                float sample = buffer[i];
                float processed = sample;

                foreach (var filter in _filters)
                {
                    processed = filter.Transform(processed);
                }

                // Dry/Wet Mix
                buffer[i] = sample * (1 - _dryWetMix) + processed * _dryWetMix;
            }
        }

    }
}
