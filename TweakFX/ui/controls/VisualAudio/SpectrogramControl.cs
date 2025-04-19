using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TweakFX.ui.controls.VisualAudio
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class SpectrogramControl : UserControl
    {
        private Bitmap spectrogram;
        private Graphics g;
        private int currentX = 0;
        private Func<float, Color> colorMap;
        private int frequencyBins = 192;
        private int framesPerPixel = 4; // можно настроить под нужную плотность
        private List<float[]> frameBuffer = new List<float[]>();

        [Browsable(false)]
        public int FrequencyBins => frequencyBins;

        public SpectrogramControl()
        {
            DoubleBuffered = true;
            ResizeRedraw = true;
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint |
                     ControlStyles.OptimizedDoubleBuffer, true);
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            // Устанавливаем дефолтную карту цвета, но только не в дизайнере
            if (!DesignMode && colorMap == null)
            {
                SetColorMap(DefaultColorMap);
            }
        }

        public void SetColorMap(Func<float, Color> map)
        {
            colorMap = map ?? DefaultColorMap;
        }

        public void AddFrame(float[] magnitudes)
        {
            if (magnitudes == null || magnitudes.Length == 0)
                return;

            if (magnitudes.Length != frequencyBins || spectrogram == null || spectrogram.Height != frequencyBins || spectrogram.Width != Width)
            {
                frequencyBins = magnitudes.Length;
                spectrogram = new Bitmap(Width, frequencyBins);
                g = Graphics.FromImage(spectrogram);
                currentX = 0;
            }

            frameBuffer.Add(magnitudes);

            if (frameBuffer.Count >= framesPerPixel)
            {
                float[] averaged = new float[frequencyBins];
                foreach (var frame in frameBuffer)
                {
                    for (int i = 0; i < frequencyBins; i++)
                        averaged[i] += frame[i];
                }

                for (int i = 0; i < frequencyBins; i++)
                    averaged[i] /= framesPerPixel;

                for (int y = 0; y < frequencyBins; y++)
                {
                    float magnitude = Math.Clamp(averaged[y], 0f, 1f);
                    Color color = colorMap != null ? colorMap(magnitude) : DefaultColorMap(magnitude);
                    spectrogram.SetPixel(currentX, frequencyBins - 1 - y, color);
                }

                currentX++;
                if (currentX >= spectrogram.Width)
                    currentX = 0;

                frameBuffer.Clear();
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (spectrogram == null) return;

            // Отрисовываем bitmap с циклическим смещением
            int width = spectrogram.Width;
            int height = spectrogram.Height;

            Rectangle srcRect1 = new Rectangle(currentX, 0, width - currentX, height);
            Rectangle destRect1 = new Rectangle(0, 0, width - currentX, height);
            e.Graphics.DrawImage(spectrogram, destRect1, srcRect1, GraphicsUnit.Pixel);

            Rectangle srcRect2 = new Rectangle(0, 0, currentX, height);
            Rectangle destRect2 = new Rectangle(width - currentX, 0, currentX, height);
            e.Graphics.DrawImage(spectrogram, destRect2, srcRect2, GraphicsUnit.Pixel);
        }

        private Color DefaultColorMap(float magnitude)
        {
            // Пример "jet" цвета
            magnitude = Math.Clamp(magnitude, 0f, 1f);
            int r = (int)(255 * Math.Clamp(1.5f - Math.Abs(4 * magnitude - 3), 0, 1));
            int g = (int)(255 * Math.Clamp(1.5f - Math.Abs(4 * magnitude - 2), 0, 1));
            int b = (int)(255 * Math.Clamp(1.5f - Math.Abs(4 * magnitude - 1), 0, 1));
            return Color.FromArgb(r, g, b);
        }
    }
}
