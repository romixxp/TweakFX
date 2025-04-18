using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dfsa.ui.controls
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;

    public class KnobControl : Control
    {
        private float angle = -135f -90f;
        private const float MinAngle = -135f - 90f;
        private const float MaxAngle = 135f - 90f;
        private bool isDragging = false;

        
        public KnobControl()
        {
            DoubleBuffered = true;
            Size = new Size(100, 100);
            MouseDown += Knob_MouseDown;
            MouseMove += Knob_MouseMove;
            MouseUp += Knob_MouseUp;
            MouseWheel += Knob_MouseWheel;
        }

        private float value;

        public event EventHandler ValueChanged;

        public float Value
        {
            get => value;
            set
            {
                if (Math.Abs(this.value - value) > 0.0001f) // можно подстроить точность
                {
                    this.value = value;
                    OnValueChanged(EventArgs.Empty);
                    Invalidate();
                }
            }
        }

        protected virtual void OnValueChanged(EventArgs e)
        {
            ValueChanged?.Invoke(this, e);
        }
        int numNeighboursToSkip = 1;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            int w = Width, h = Height;
            Rectangle rect = new(20, 20, w - 40, h - 40);
            //Rectangle el = new Rectangle(0, 0, 300, 300);
            Rectangle shadowCircle = new(rect.X-3, rect.Y-4, rect.Width+6, rect.Height+6);
            using (GraphicsPath path = new())
            {
                path.AddEllipse(shadowCircle);
                //using (PathGradientBrush brush = new PathGradientBrush(path))
                using (LinearGradientBrush fillBrush = new(rect, Color.FromArgb(0,0,0), Color.FromArgb(0, 0, 0), LinearGradientMode.BackwardDiagonal))
                {
                    //                    brush.CenterColor = Color.Magenta;
                    //                    brush.SurroundColors = new Color[] { Color.FromArgb(60, 0, 60) };
                    ColorBlend colorBlend = new ColorBlend();
                    colorBlend.Colors = [Color.FromArgb(170/2, 20/2, 180/2), Color.FromArgb(252, 108, 255), Color.FromArgb(30, 0, 30)];
                    colorBlend.Positions = [0f, 0.4f, 1f];
                    fillBrush.InterpolationColors = colorBlend;
                    g.FillEllipse(fillBrush, shadowCircle);
                }
            }

            // Градиентный круг
            using (GraphicsPath path = new())
            {
                path.AddEllipse(rect);

                using (PathGradientBrush brush = new PathGradientBrush(path))
                {
                    brush.CenterPoint = new PointF(
                        rect.X + rect.Width / 2f,
                        rect.Y + rect.Height / 2f
                    );

                    brush.CenterColor = Color.FromArgb(255, 255, 255); // яркое серебро в центре
                    brush.SurroundColors = new Color[] { Color.FromArgb(40,40,40) }; // тёмные края

                    g.FillEllipse(brush, rect);
                }

                // Эффект "расходящихся линий", чтобы симулировать щетку по кругу (вручную)
                PointF center = new PointF(rect.X + rect.Width / 2f, rect.Y + rect.Height / 2f);
                int rays = 325; // количество "щетинок"
                double angleStep = 2 * Math.PI / rays;

                for (int i = 0; i < rays; i++)
                {
                    double angle = i * angleStep;
                    float x = center.X + (float)(rect.Width / 2 * Math.Cos(angle));
                    float y = center.Y + (float)(rect.Height / 2 * Math.Sin(angle));

                    using (Pen pen = new Pen(Color.FromArgb(23, 26, 32), 0.5f))
                    {
                        g.DrawLine(pen, center, new PointF(x, y));
                    }
                }
            }
            int markers = 50;
            // Внешние маркеры
            for (int i = 0; i <= markers; i++)
            {
                float markerAngle = MinAngle + i * (270f / markers);

                // Пропускаем маркеры на 0 дБ и два соседних маркера
                if (IsInSkipRange(markerAngle))
                {
                    continue;  // Пропускаем рисование маркера, если угол близок к 0 дБ или его соседям
                }

                if (Value != 0f)
                    DrawExternalMarker(g, rect, markerAngle, i / (float)markers <= Value);
                else
                    DrawExternalMarker(g, rect, markerAngle, false);
            }

            // Индикатор
            PointF knobStart = GetPointOnCircle(rect, angle - 2, 0.7f);
            PointF knobEnd = GetPointOnCircle(rect, angle - 2, 0.9f);
            using (Pen knobPen = new Pen(Color.White, 3))
            {
                knobPen.StartCap = LineCap.Round;
                knobPen.EndCap = LineCap.Round;
                g.DrawLine(knobPen, knobStart, knobEnd);
            }
        }
        private bool IsInSkipRange(float markerAngle)
        {
            // Рассчитываем, нужно ли пропустить маркер
            float deltaAngle = Math.Abs(markerAngle - 0f);

            // Проверка, находится ли маркер в пределах от 0 дБ и соседей
            for (int i = 1; i <= numNeighboursToSkip; i++)
            {
                if (Math.Abs(markerAngle - i * (270f / 60)) < 1.5f || Math.Abs(markerAngle + i * (270f / 60)) < 1.5f)
                {
                    return true;
                }
            }

            return deltaAngle < 1.5f; // Пропуск для 0 дБ
        }
        private void DrawExternalMarker(Graphics g, Rectangle rect, float angle, bool active)
        {
            PointF start = GetPointOnCircle(rect, angle, 1.2f);
            PointF end = GetPointOnCircle(rect, angle, 1.3f);
            using (Pen pen = new Pen(active ? Color.FromArgb(207, 174, 215) : Color.FromArgb(110, 110, 110), 2f))
            {
                g.DrawLine(pen, start, end);
            }
        }

        private PointF GetPointOnCircle(Rectangle rect, float angle, float radiusMultiplier)
        {
            double rad = angle * Math.PI / 180;
            float cx = rect.X + rect.Width / 2;
            float cy = rect.Y + rect.Height / 2;
            float radius = rect.Width / 2 * radiusMultiplier;
            return new PointF(cx + (float)(radius * Math.Cos(rad)), cy + (float)(radius * Math.Sin(rad)));
        }
        Point lastMousePosition;

        private void Knob_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                lastMousePosition = e.Location;
            }
        }

        private void Knob_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                int deltaX = e.X - lastMousePosition.X;
                int deltaY = e.Y - lastMousePosition.Y;

                // Чувствительность — подбери под себя
                float sensitivity = 1.1f;
                float deltaAngleX = deltaX * sensitivity;
               
                float newAngleX = angle + deltaAngleX;
                newAngleX = Math.Max(MinAngle, Math.Min(MaxAngle, newAngleX));
                angle = newAngleX;

                Value = (angle - MinAngle) / (MaxAngle - MinAngle);

                lastMousePosition = e.Location;

                Invalidate();
            }
        }

        private void Knob_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                isDragging = false;
        }

        private void Knob_MouseWheel(object sender, MouseEventArgs e)
        {
            Value = Math.Max(0f, Math.Min(1f, Value + (e.Delta > 0 ? 0.033f : -0.033f)));
            angle = MinAngle + Value * (MaxAngle - MinAngle);
            Invalidate();
        }
    }

}