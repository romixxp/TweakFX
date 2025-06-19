using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TweakFX.core.effects.eq;

namespace TweakFX.core.dsp
{
    public class BiquadFilter
    {
        private float a0, a1, a2, b1, b2;
        private float x1, x2; // предыдущие входы
        private float y1, y2; // предыдущие выходы

        private BiquadFilter() { }

        public void Reset()
        {
            x1 = x2 = y1 = y2 = 0f;
        }

        public float Transform(float x0)
        {
            float y0 = a0 * x0 + a1 * x1 + a2 * x2 - b1 * y1 - b2 * y2;
            x2 = x1;
            x1 = x0;
            y2 = y1;
            y1 = y0;
            return y0;
        }

        public static BiquadFilter Create(FilterType type, int sampleRate, float frequency, float Q = 1f, float gainDB = 0f)
        {
            switch (type)
            {
                case FilterType.Peaking: return PeakingEQ(sampleRate, frequency, Q, gainDB);
                case FilterType.LowShelf: return LowShelf(sampleRate, frequency, gainDB);
                case FilterType.HighShelf: return HighShelf(sampleRate, frequency, gainDB);
                case FilterType.LowCut: return LowPass(sampleRate, frequency, Q);
                case FilterType.HighCut: return HighPass(sampleRate, frequency, Q);
                case FilterType.BandPass: return BandPass(sampleRate, frequency, Q);
                case FilterType.BandStop: return BandStop(sampleRate, frequency, Q);
                case FilterType.Notch: return Notch(sampleRate, frequency, Q);
                case FilterType.AllPass: return AllPass(sampleRate, frequency, Q);
                default: throw new ArgumentException("Unsupported filter type");
            }
        }

        // Peaking EQ
        public static BiquadFilter PeakingEQ(int sampleRate, float freq, float Q, float gainDB)
        {
            float A = (float)Math.Pow(10, gainDB / 40);
            float omega = 2 * (float)Math.PI * freq / sampleRate;
            float alpha = (float)Math.Sin(omega) / (2 * Q);
            float cosw = (float)Math.Cos(omega);

            float b0 = 1 + alpha * A;
            float b1 = -2 * cosw;
            float b2 = 1 - alpha * A;
            float a0 = 1 + alpha / A;
            float a1 = -2 * cosw;
            float a2 = 1 - alpha / A;

            return new BiquadFilter
            {
                a0 = b0 / a0,
                a1 = b1 / a0,
                a2 = b2 / a0,
                b1 = a1 / a0,
                b2 = a2 / a0
            };
        }

        public static BiquadFilter LowShelf(int sampleRate, float freq, float gainDB)
        {
            float A = (float)Math.Pow(10, gainDB / 40);
            float omega = 2 * (float)Math.PI * freq / sampleRate;
            float sn = (float)Math.Sin(omega);
            float cs = (float)Math.Cos(omega);
            float beta = (float)Math.Sqrt(A) / 1f;

            float b0 = A * ((A + 1) - (A - 1) * cs + 2 * beta * sn);
            float b1 = 2 * A * ((A - 1) - (A + 1) * cs);
            float b2 = A * ((A + 1) - (A - 1) * cs - 2 * beta * sn);
            float a0 = (A + 1) + (A - 1) * cs + 2 * beta * sn;
            float a1 = -2 * ((A - 1) + (A + 1) * cs);
            float a2 = (A + 1) + (A - 1) * cs - 2 * beta * sn;

            return new BiquadFilter
            {
                a0 = b0 / a0,
                a1 = b1 / a0,
                a2 = b2 / a0,
                b1 = a1 / a0,
                b2 = a2 / a0
            };
        }

        public static BiquadFilter HighShelf(int sampleRate, float freq, float gainDB)
        {
            float A = (float)Math.Pow(10, gainDB / 40);
            float omega = 2 * (float)Math.PI * freq / sampleRate;
            float sn = (float)Math.Sin(omega);
            float cs = (float)Math.Cos(omega);
            float beta = (float)Math.Sqrt(A) / 1f;

            float b0 = A * ((A + 1) + (A - 1) * cs + 2 * beta * sn);
            float b1 = -2 * A * ((A - 1) + (A + 1) * cs);
            float b2 = A * ((A + 1) + (A - 1) * cs - 2 * beta * sn);
            float a0 = (A + 1) - (A - 1) * cs + 2 * beta * sn;
            float a1 = 2 * ((A - 1) - (A + 1) * cs);
            float a2 = (A + 1) - (A - 1) * cs - 2 * beta * sn;

            return new BiquadFilter
            {
                a0 = b0 / a0,
                a1 = b1 / a0,
                a2 = b2 / a0,
                b1 = a1 / a0,
                b2 = a2 / a0
            };
        }

        public static BiquadFilter LowPass(int sampleRate, float freq, float Q)
        {
            float omega = 2 * (float)Math.PI * freq / sampleRate;
            float alpha = (float)Math.Sin(omega) / (2 * Q);
            float cosw = (float)Math.Cos(omega);

            float b0 = (1 - cosw) / 2;
            float b1 = 1 - cosw;
            float b2 = (1 - cosw) / 2;
            float a0 = 1 + alpha;
            float a1 = -2 * cosw;
            float a2 = 1 - alpha;

            return new BiquadFilter
            {
                a0 = b0 / a0,
                a1 = b1 / a0,
                a2 = b2 / a0,
                b1 = a1 / a0,
                b2 = a2 / a0
            };
        }

        public static BiquadFilter HighPass(int sampleRate, float freq, float Q)
        {
            float omega = 2 * (float)Math.PI * freq / sampleRate;
            float alpha = (float)Math.Sin(omega) / (2 * Q);
            float cosw = (float)Math.Cos(omega);

            float b0 = (1 + cosw) / 2;
            float b1 = -(1 + cosw);
            float b2 = (1 + cosw) / 2;
            float a0 = 1 + alpha;
            float a1 = -2 * cosw;
            float a2 = 1 - alpha;

            return new BiquadFilter
            {
                a0 = b0 / a0,
                a1 = b1 / a0,
                a2 = b2 / a0,
                b1 = a1 / a0,
                b2 = a2 / a0
            };
        }

        public static BiquadFilter BandPass(int sampleRate, float freq, float Q)
        {
            float omega = 2 * (float)Math.PI * freq / sampleRate;
            float alpha = (float)Math.Sin(omega) / (2 * Q);
            float cosw = (float)Math.Cos(omega);

            float b0 = alpha;
            float b1 = 0;
            float b2 = -alpha;
            float a0 = 1 + alpha;
            float a1 = -2 * cosw;
            float a2 = 1 - alpha;

            return new BiquadFilter
            {
                a0 = b0 / a0,
                a1 = b1 / a0,
                a2 = b2 / a0,
                b1 = a1 / a0,
                b2 = a2 / a0
            };
        }

        public static BiquadFilter BandStop(int sampleRate, float freq, float Q)
            => Notch(sampleRate, freq, Q);

        public static BiquadFilter Notch(int sampleRate, float freq, float Q)
        {
            float omega = 2 * (float)Math.PI * freq / sampleRate;
            float alpha = (float)Math.Sin(omega) / (2 * Q);
            float cosw = (float)Math.Cos(omega);

            float b0 = 1;
            float b1 = -2 * cosw;
            float b2 = 1;
            float a0 = 1 + alpha;
            float a1 = -2 * cosw;
            float a2 = 1 - alpha;

            return new BiquadFilter
            {
                a0 = b0 / a0,
                a1 = b1 / a0,
                a2 = b2 / a0,
                b1 = a1 / a0,
                b2 = a2 / a0
            };
        }

        public static BiquadFilter AllPass(int sampleRate, float freq, float Q)
        {
            float omega = 2 * (float)Math.PI * freq / sampleRate;
            float alpha = (float)Math.Sin(omega) / (2 * Q);
            float cosw = (float)Math.Cos(omega);

            float b0 = 1 - alpha;
            float b1 = -2 * cosw;
            float b2 = 1 + alpha;
            float a0 = 1 + alpha;
            float a1 = -2 * cosw;
            float a2 = 1 - alpha;

            return new BiquadFilter
            {
                a0 = b0 / a0,
                a1 = b1 / a0,
                a2 = b2 / a0,
                b1 = a1 / a0,
                b2 = a2 / a0
            };
        }
    }

}
