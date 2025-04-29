using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.Devices;
using TweakFX.core;

namespace TweakFX.ui.controls.VisualAudio
{
    public class Oscilloscope : Control
    {
        private float[] _samples;
        private int _maxSamples; 
        private const float MaxAmplitude = 1.0f; 
        private const int SmoothingWindow = 10;  

        public Oscilloscope()
        {
            _samples = new float[192]; 
            _maxSamples = 192;          
            this.DoubleBuffered = true;
        }

        public void UpdateBuffer(float[] newSamples)
        {
            try
            {
                Array.Copy(_samples, newSamples.Length, _samples, 0, _samples.Length - newSamples.Length);
            }
            catch (Exception ex)
            {
                Application.Exit();
            }

            Array.Copy(newSamples, 0, _samples, _samples.Length - newSamples.Length, newSamples.Length);

            Invalidate();
        }


        private void SmoothSignal()
        {
            for (int i = 0; i < _samples.Length; i++)
            {
                int start = Math.Max(0, i - SmoothingWindow / 2);
                int end = Math.Min(_samples.Length - 1, i + SmoothingWindow / 2);
                float sum = 0;
                int count = 0;

                for (int j = start; j <= end; j++)
                {
                    sum += _samples[j];
                    count++;
                }

                _samples[i] = sum / count;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (_samples == null || _samples.Length < 2) return;

            var g = e.Graphics;
            g.Clear(Color.FromArgb(1, 10, 25));
            g.SmoothingMode = SmoothingMode.AntiAlias;
            //SmoothSignal();
            int width = Width;
            int height = Height;
            int centerY = height / 2;

            float xScale = (float)width / _samples.Length;
            float yScale = (float)(height / 2);

            using (GraphicsPath path = new GraphicsPath())
            {
                for (int i = 0; i < _samples.Length; i++)
                {
                    float x = i * xScale;
                    float y = centerY - _samples[i] * yScale;
                    y = Math.Clamp(y, 0, height);

                    if (i == 0)
                        path.StartFigure();
                    else
                        path.AddLine((i - 1) * xScale, centerY - _samples[i - 1] * yScale, x, y);
                }

                using (Pen pen = new Pen(Color.Lime, 3f))
                {
                    g.DrawPath(pen, path);
                }
            }
        }
    }
}
