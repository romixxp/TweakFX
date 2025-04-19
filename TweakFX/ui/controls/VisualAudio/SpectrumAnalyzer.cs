using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TweakFX.ui.controls.VisualAudio
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using NAudio.Dsp;

    public class SpectrumAnalyzer : Control
    {
        private const int FFT_SIZE = 2048;
        private Complex[] _fftBuffer = new Complex[FFT_SIZE];
        private float[] _spectrum = new float[FFT_SIZE / 2];
        private int _bufferOffset = 0;

        public SpectrumAnalyzer()
        {
            this.DoubleBuffered = true;
            this.BackColor = Color.Black;
        }

        public void UpdateBuffer(float[] newSamples)
        {
            for (int i = 0; i < newSamples.Length; i++)
            {
                _fftBuffer[_bufferOffset].X = (float)(newSamples[i] * FastFourierTransform.HammingWindow(_bufferOffset, FFT_SIZE));
                _fftBuffer[_bufferOffset].Y = 0;
                _bufferOffset++;

                if (_bufferOffset >= FFT_SIZE)
                {
                    _bufferOffset = 0;
                    FastFourierTransform.FFT(true, (int)Math.Log(FFT_SIZE, 2.0), _fftBuffer);

                    for (int j = 0; j < _spectrum.Length; j++)
                    {
                        float mag = (float)Math.Sqrt(_fftBuffer[j].X * _fftBuffer[j].X + _fftBuffer[j].Y * _fftBuffer[j].Y);
                        _spectrum[j] = 20 * (float)Math.Log10(mag + 1e-6f); // в dB
                    }

                    Invalidate(); // перерисовать только после нового анализа
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (_spectrum == null) return;

            var g = e.Graphics;
            g.Clear(this.BackColor);

            Pen pen = new Pen(Color.LimeGreen, 2);
            PointF[] points = new PointF[_spectrum.Length];

            for (int i = 1; i < _spectrum.Length; i++)
            {
                float freqRatio = (float)Math.Log10(1 + 9f * i / _spectrum.Length); // логарифмическое распределение
                float x = freqRatio * Width;
                float y = Height - ((_spectrum[i] + 100) / 100f) * Height;
                points[i] = new PointF(x, Math.Clamp(y, 0, Height));
            }

            g.DrawLines(pen, points);
        }
    }
}
