using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TweakFX.ui.controls
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public class EqualizerBandControl : Control
    {
        private float _value = 0f;
        public float Value
        {
            get => _value;
            set
            {
                float newVal = Math.Max(MinValue, Math.Min(MaxValue, value));
                if (Math.Abs(_value - newVal) > 0.001f)
                {
                    _value = newVal;
                    Invalidate();
                    ValueChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        public float MinValue { get; set; } = -60f;
        public float MaxValue { get; set; } = 12f;

        public event EventHandler ValueChanged;

        private bool isDragging = false;

        public EqualizerBandControl()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.UserPaint, true);

            Width = 30;
            Height = 200;
            BackColor = Color.FromArgb(30, 30, 30);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            using (var bg = new SolidBrush(BackColor))
                g.FillRectangle(bg, ClientRectangle);

            // Дорожка
            var trackRect = new Rectangle(Width / 2 - 3, 10, 6, Height - 20);
            using (var trackBrush = new SolidBrush(Color.FromArgb(60, 60, 60)))
                g.FillRectangle(trackBrush, trackRect);

            // Ползунок
            float yPos = ValueToY(Value) - 8;
            var faderRect = new Rectangle(Width / 2 - 10, (int)yPos, 20, 16);

            using (var brush = new SolidBrush(Color.Silver))
                g.FillRectangle(brush, faderRect);

            using (var pen = new Pen(Color.Black))
                g.DrawRectangle(pen, faderRect);
        }

        private float ValueToY(float val)
        {
            float percent = (val - MinValue) / (MaxValue - MinValue);
            return 10 + (1f - percent) * (Height - 20);
        }

        private float YToValue(int y)
        {
            float percent = 1f - ((y - 10f) / (Height - 20f));
            return MinValue + percent * (MaxValue - MinValue);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                Value = YToValue(e.Y);
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (isDragging)
            {
                Value = YToValue(e.Y);
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            isDragging = false;
        }
    }
}
