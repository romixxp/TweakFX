using System;
using System.Numerics;

namespace TweakFX.core.effects.eq
{
    class LogScale
    {
        const int sampleRate = 44100;
        const int fftSize = 2048;

        // Частотные границы 10 фиксированных полос
        static readonly double[] bandEdges = new double[]
        {
            20, 30,
            31, 60,
            61, 124,
            125, 249,
            250, 499,
            500, 999,
            1000, 1999,
            2000, 3999,
            4000, 7999,
            8000, 22000
        };
        // Пример коэффициентов компенсации для 10 полос (примерно)
        float[] compensation = new float[] {
    1.5f, 1.3f, 1.1f, 1.0f, 0.9f, 0.8f, 0.7f, 0.6f, 0.5f, 0.4f
};

        public static float[] Process(float[] buffer)
        {
            const int fftSize = 2048;
            float[] windowed = ApplyHannWindow(buffer, fftSize);
            Complex[] spectrum = FFT(windowed);

            float[] magnitudes = new float[fftSize / 2];
            for (int i = 0; i < magnitudes.Length; i++)
                magnitudes[i] = (float)spectrum[i].Magnitude;

            float[] bandAmplitudes = new float[10];

            double[] bandEdges = new double[]
            {
        20, 30,
        31, 60,
        61, 124,
        125, 249,
        250, 499,
        500, 999,
        1000, 1999,
        2000, 3999,
        4000, 7999,
        8000, 22000
            };

            float[] compensation = new float[] { 2.5f, 2.0f, 1.5f, 1.2f, 1.0f, 0.8f, 0.7f, 0.6f, 0.5f, 0.4f };

            float[] rmsValues = new float[10];
            for (int i = 0; i < 10; i++)
            {
                double fLow = bandEdges[i * 2];
                double fHigh = bandEdges[i * 2 + 1];

                int binLow = (int)(fLow / sampleRate * fftSize);
                int binHigh = (int)(fHigh / sampleRate * fftSize);

                binLow = Math.Clamp(binLow, 0, magnitudes.Length - 1);
                binHigh = Math.Clamp(binHigh, binLow + 1, magnitudes.Length);

                double sumSquares = 0;
                int count = binHigh - binLow;
                for (int b = binLow; b < binHigh; b++)
                    sumSquares += magnitudes[b] * magnitudes[b];

                float rms = (float)Math.Sqrt(sumSquares / count);
                rms *= compensation[i];
                rmsValues[i] = rms;
            }

            float maxRms = rmsValues.Max();

            for (int i = 0; i < 10; i++)
            {
                float normalizedRms = rmsValues[i] / (maxRms + 1e-12f);
                float db = 20f * (float)Math.Log10(normalizedRms + 1e-12f);
                db = Math.Clamp(db, -60f, 20f); // Немного расширил верхнюю границу
                bandAmplitudes[i] = db;
            }

            return bandAmplitudes;
        }

        static float[] ApplyHannWindow(float[] input, int size)
        {
            float[] output = new float[size];
            for (int i = 0; i < size && i < input.Length; i++)
            {
                double w = 0.5 * (1 - Math.Cos(2 * Math.PI * i / (size - 1)));
                output[i] = (float)(input[i] * w);
            }
            return output;
        }

        static Complex[] FFT(float[] data)
        {
            Complex[] complex = new Complex[fftSize];
            for (int i = 0; i < fftSize; i++)
                complex[i] = i < data.Length ? new Complex(data[i], 0) : Complex.Zero;

            FFT_Recursive(complex);
            return complex;
        }

        static void FFT_Recursive(Complex[] buffer)
        {
            int n = buffer.Length;
            if (n <= 1)
                return;

            Complex[] even = new Complex[n / 2];
            Complex[] odd = new Complex[n / 2];

            for (int i = 0; i < n / 2; i++)
            {
                even[i] = buffer[i * 2];
                odd[i] = buffer[i * 2 + 1];
            }

            FFT_Recursive(even);
            FFT_Recursive(odd);

            for (int k = 0; k < n / 2; k++)
            {
                Complex t = Complex.FromPolarCoordinates(1.0, -2 * Math.PI * k / n) * odd[k];
                buffer[k] = even[k] + t;
                buffer[k + n / 2] = even[k] - t;
            }
        }
    }
}