using System;
using System.Drawing;
using System.Windows.Forms;
using NAudio.Dsp;

namespace TweakFX.ui.controls.VisualAudio
{
    public class SpectrumAnalyzer : Control
    {
        private const int FFT_SIZE = 192; // было 192
        private Complex[] _fftBuffer = new Complex[FFT_SIZE];
        private float[] _spectrum = new float[FFT_SIZE / 2];

        public SpectrumAnalyzer()
        {
            this.DoubleBuffered = true;
            this.BackColor = Color.Black;
        }

        /// <summary>
        /// Принимает блок данных длиной ровно FFT_SIZE и сразу считает спектр
        /// </summary>
        public void UpdateBuffer(float[] newSamples)
        {
            if (newSamples.Length != FFT_SIZE)
                throw new ArgumentException($"newSamples must be exactly {FFT_SIZE} samples");

            // Заполнение буфера и окно Хэмминга
            for (int i = 0; i < FFT_SIZE; i++)
            {
                float window = (float)FastFourierTransform.HammingWindow(i, FFT_SIZE);
                _fftBuffer[i].X = newSamples[i] * window;
                _fftBuffer[i].Y = 0;
            }

            // Выполнение БПФ
            FastFourierTransform.FFT(true, (int)Math.Log(FFT_SIZE, 2), _fftBuffer);

            // Расчёт спектра
            for (int i = 0; i < _spectrum.Length; i++)
            {
                float re = _fftBuffer[i].X;
                float im = _fftBuffer[i].Y;
                float magnitude = (float)Math.Sqrt(re * re + im * im);
                _spectrum[i] = 20 * (float)Math.Log10(magnitude + 1e-6f); // в dB
            }

            Invalidate(); // перерисовать
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (_spectrum == null) return;

            var g = e.Graphics;
            g.Clear(this.BackColor);

            Pen pen = new Pen(Color.LimeGreen, 2);
            PointF[] points = new PointF[_spectrum.Length];

            for (int i = 0; i < _spectrum.Length; i++)
            {
                // логарифмическая шкала по оси X
                float logX = (float)Math.Log10(1 + i) / (float)Math.Log10(_spectrum.Length);
                float x = logX * Width;

                // шкала по Y (от -100 до 0 дБ)
                float y = Height - ((_spectrum[i] + 100) / 100f) * Height;
                y = Math.Clamp(y, 0, Height);

                points[i] = new PointF(x, y);
            }

            if (_spectrum.Length > 1)
                g.DrawLines(pen, points);
        }
    }
}