using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Numerics;
using System.Windows.Forms;
using MathNet.Numerics.IntegralTransforms;

namespace TweakFX.core.effects.eq
{
    public class FrequencyGainControl : Control
    {
        private readonly float[] gains = new float[10];
        private readonly string[] frequencies = { "31", "62", "125", "250", "500", "1k", "2k", "4k", "8k", "16k" };
        private readonly int[] freqBins = { 31, 62, 125, 250, 500, 1000, 2000, 4000, 8000, 16000 };

        private const float maxGain = 12f;
        private const float minGain = -12f;

        public FrequencyGainControl()
        {
            DoubleBuffered = true;
            ResizeRedraw = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
            this.UpdateStyles();
        }

        /// <summary>
        /// Возвращает ближайшую степень двойки >= n
        /// </summary>
        private int NextPowerOfTwo(int n)
        {
            int pow = 1;
            while (pow < n)
                pow <<= 1;
            return pow;
        }

        /// <summary>
        /// Принимает аудиобуфер сэмплов (моно, нормализованные float [-1..1]) и sampleRate
        /// Вычисляет амплитуды в 10 полосах и обновляет контрол.
        /// </summary>
        public void UpdateFromAudioBuffer(float[] buffer, int sampleRate)
        {
            if (buffer == null || buffer.Length == 0)
                return;

            int fftSize = NextPowerOfTwo(buffer.Length);

            float[] fftInput = new float[fftSize];
            // Копируем данные и нулевое дополнение
            Array.Clear(fftInput, 0, fftSize);
            Array.Copy(buffer, 0, fftInput, 0, buffer.Length);

            // Создаем комплексный массив для FFT и применяем окно Хэмминга
            Complex[] complexSamples = new Complex[fftSize];
            for (int i = 0; i < fftSize; i++)
            {
                double windowValue = 0.54 - 0.46 * Math.Cos(2 * Math.PI * i / (fftSize - 1)); // окно Хэмминга
                complexSamples[i] = new Complex(fftInput[i] * windowValue, 0);
            }

            // Выполняем FFT
            Fourier.Forward(complexSamples, FourierOptions.Matlab);

            // Расчёт амплитуд для каждой полосы
            float[] bandAmplitudes = new float[gains.Length];
            for (int i = 0; i < gains.Length; i++)
            {
                bandAmplitudes[i] = GetBandAmplitude(complexSamples, freqBins[i], sampleRate, fftSize);
            }

            // Конвертируем амплитуды в децибелы и ограничиваем
            for (int i = 0; i < bandAmplitudes.Length; i++)
            {
                float db = 20 * (float)Math.Log10(bandAmplitudes[i] + 1e-6f); // +1e-6 чтобы избежать log(0)
                gains[i] = Math.Max(minGain, Math.Min(maxGain, db));
            }

            // Обновляем UI
            if (this.IsHandleCreated)
            {
                this.BeginInvoke((Action)(() =>
                {
                    UpdateBuffer(gains);
                }));
            }
        }

        /// <summary>
        /// Возвращает амплитуду сигнала для полосы около freq Hz
        /// усредняя в диапазоне ±10% от freq.
        /// </summary>
        private float GetBandAmplitude(Complex[] spectrum, int freq, int sampleRate, int fftSize)
        {
            float freqLow = freq * 0.9f;
            float freqHigh = freq * 1.1f;

            int binLow = (int)(freqLow * fftSize / sampleRate);
            int binHigh = (int)(freqHigh * fftSize / sampleRate);

            binLow = Math.Max(binLow, 0);
            binHigh = Math.Min(binHigh, spectrum.Length - 1);

            float sum = 0;
            int count = 0;
            for (int bin = binLow; bin <= binHigh; bin++)
            {
                sum += (float)spectrum[bin].Magnitude / fftSize; // нормировка по размеру FFT
                count++;
            }

            return count > 0 ? sum / count : 0;
        }

        /// <summary>
        /// Копируем данные и вызываем перерисовку
        /// </summary>
        public void UpdateBuffer(float[] newGains)
        {
            if (newGains == null || newGains.Length != gains.Length)
                throw new ArgumentException($"Нужно ровно {gains.Length} значений.");

            Array.Copy(newGains, gains, gains.Length);
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(Color.FromArgb(30, 30, 30));

            int width = Width;
            int height = Height;

            int margin = 10;
            int availableWidth = width - margin * 2;
            int availableHeight = height - margin * 2;

            int bandWidth = availableWidth / gains.Length;
            int maxRectHeight = availableHeight - 40;

            for (int i = 0; i < gains.Length; i++)
            {
                float normalizedGain = (gains[i] - minGain) / (maxGain - minGain);
                int rectHeight = (int)(normalizedGain * maxRectHeight);

                int x = margin + i * bandWidth + bandWidth / 8;
                int y = margin + (maxRectHeight - rectHeight);

                Rectangle rect = new Rectangle(x, y, bandWidth * 3 / 4, rectHeight);

                Color fillColor = gains[i] >= 0 ? Color.LimeGreen : Color.OrangeRed;

                using (Brush brush = new SolidBrush(fillColor))
                    g.FillRectangle(brush, rect);

                using (Pen pen = new Pen(Color.Black, 1))
                    g.DrawRectangle(pen, rect);

                // Подпись частот
                string freqText = frequencies[i];
                var font = this.Font;
                var textSize = g.MeasureString(freqText, font);
                float textX = x + (bandWidth * 3 / 4 - textSize.Width) / 2;
                float textY = margin + maxRectHeight + 5;

                using (Brush textBrush = new SolidBrush(Color.White))
                    g.DrawString(freqText, font, textBrush, textX, textY);

                // Подпись гейна
                string gainText = $"{gains[i]:0.0} dB";
                var gainTextSize = g.MeasureString(gainText, font);
                float gainTextX = x + (bandWidth * 3 / 4 - gainTextSize.Width) / 2;
                float gainTextY = y - gainTextSize.Height - 2;

                using (Brush gainBrush = new SolidBrush(Color.LightGray))
                    g.DrawString(gainText, font, gainBrush, gainTextX, gainTextY);
            }
        }
    }
}
