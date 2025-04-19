using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TweakFX.ui.controls.unused
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public class OscilloscopeControl : Control
    {
        // Данные для отображения
        private float[] audioBuffer;

        // Свойство для доступа к данным
        public float[] AudioData
        {
            get { return audioBuffer; }
            private set
            {
                audioBuffer = value;
                Invalidate(); // Перерисовываем при изменении данных
            }
        }

        private Timer redrawTimer;

        public int GridSpacing { get; set; } = 20;

        public OscilloscopeControl()
        {
            DoubleBuffered = true;
            BackColor = Color.Black;

            redrawTimer = new Timer();
            redrawTimer.Interval = 30;
            redrawTimer.Tick += (s, e) => Invalidate();
            redrawTimer.Start();
        }

        // Метод для обновления данных с буфером
        public void UpdateWave(float[] buffer)
        {
            if (buffer == null || buffer.Length == 0)
                return;

            AudioData = buffer; // Обновляем данные и инициируем перерисовку
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            g.Clear(BackColor);

            // Если данные не загружены, ничего не рисуем
            if (audioBuffer == null || audioBuffer.Length < 2)
                return;

            DrawGrid(g);

            Pen oscilloPen = new Pen(Color.Lime, 1);

            int midY = ClientSize.Height / 2;
            float width = ClientSize.Width;
            float height = ClientSize.Height;
            int samples = audioBuffer.Length;

            // Рисуем осциллограмму
            for (int i = 0; i < samples - 1; i++)
            {
                float x1 = (float)i / (samples - 1) * width;
                float x2 = (float)(i + 1) / (samples - 1) * width;

                float y1 = midY - audioBuffer[i] * (height / 2);
                float y2 = midY - audioBuffer[i + 1] * (height / 2);

                g.DrawLine(oscilloPen, x1, y1, x2, y2);
            }
        }

        private void DrawGrid(Graphics g)
        {
            Pen gridPen = new Pen(Color.FromArgb(30, Color.White));

            float width = ClientSize.Width;
            float height = ClientSize.Height;

            for (int x = 0; x < width; x += GridSpacing)
            {
                g.DrawLine(gridPen, x, 0, x, height);
            }

            for (int y = 0; y < height; y += GridSpacing)
            {
                g.DrawLine(gridPen, 0, y, width, y);
            }
        }

        // Метод для явного обновления и перерисовки
        public void RefreshWave()
        {
            Invalidate();
        }
    }
}
