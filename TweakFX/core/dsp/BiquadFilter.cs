using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TweakFX.core.dsp
{
    public class BiquadFilter
    {
        private float a0, a1, a2, b1, b2;
        private float x1, x2; // предыдущие входы
        private float y1, y2; // предыдущие выходы

        private BiquadFilter() { }

        public static BiquadFilter PeakingEQ(int sampleRate, float freq, float bandwidth, float gainDB)
        {
            var filter = new BiquadFilter();

            float A = (float)Math.Pow(10, gainDB / 40);
            float omega = 2 * (float)Math.PI * freq / sampleRate;
            float sn = (float)Math.Sin(omega);
            float cs = (float)Math.Cos(omega);
            float alpha = sn * (float)Math.Sinh(Math.Log(2) / 2 * bandwidth * omega / sn);

            float b0 = 1 + alpha * A;
            float b1 = -2 * cs;
            float b2 = 1 - alpha * A;
            float a0 = 1 + alpha / A;
            float a1 = -2 * cs;
            float a2 = 1 - alpha / A;

            // Normalize coefficients
            filter.a0 = b0 / a0;
            filter.a1 = b1 / a0;
            filter.a2 = b2 / a0;
            filter.b1 = a1 / a0;
            filter.b2 = a2 / a0;

            Debug.WriteLine("BiquadFilter PeakingEQ: " +
                $"a0={filter.a0}, a1={filter.a1}, a2={filter.a2}, b1={filter.b1}, b2={filter.b2}");
            return filter;
        }
        public static BiquadFilter LowShelf(int sampleRate, float freq, float gainDB)
        {
            var filter = new BiquadFilter();
            float A = (float)Math.Pow(10, gainDB / 40);
            float omega = 2 * (float)Math.PI * freq / sampleRate;
            float sn = (float)Math.Sin(omega);
            float cs = (float)Math.Cos(omega);
            float beta = (float)Math.Sqrt(A) / 1f; // S = 1

            float b0 = A * ((A + 1) - (A - 1) * cs + 2 * beta * sn);
            float b1 = 2 * A * ((A - 1) - (A + 1) * cs);
            float b2 = A * ((A + 1) - (A - 1) * cs - 2 * beta * sn);
            float a0 = (A + 1) + (A - 1) * cs + 2 * beta * sn;
            float a1 = -2 * ((A - 1) + (A + 1) * cs);
            float a2 = (A + 1) + (A - 1) * cs - 2 * beta * sn;

            filter.a0 = b0 / a0;
            filter.a1 = b1 / a0;
            filter.a2 = b2 / a0;
            filter.b1 = a1 / a0;
            filter.b2 = a2 / a0;

            return filter;
        }

        public static BiquadFilter HighShelf(int sampleRate, float freq, float gainDB)
        {
            var filter = new BiquadFilter();
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

            filter.a0 = b0 / a0;
            filter.a1 = b1 / a0;
            filter.a2 = b2 / a0;
            filter.b1 = a1 / a0;
            filter.b2 = a2 / a0;

            return filter;
        }

        public float Transform(float x0)
        {
            float y0 = a0 * x0 + a1 * x1 + a2 * x2 - b1 * y1 - b2 * y2;

            // shift delay line
            x2 = x1;
            x1 = x0;

            y2 = y1;
            y1 = y0;

            return y0;
        }
    }
}
