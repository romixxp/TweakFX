using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TweakFX.core.client_pereferences
{
    public partial class Pereferences_Form : Form
    {
        private int borderRadius = 30;
        private int borderThickness = 5;
        private Color borderColor = Color.FromArgb(100,100,100);
        public Pereferences_Form()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            //this.Size = new Size(400, 300);
            this.DoubleBuffered = true;
            this.Padding = new Padding(borderThickness);
            var asioDrivers = AudioDriverUtils.GetAsioDriverNames();
            cbAsioDrivers.Items.Clear();
            foreach (var driver in asioDrivers)
            {
                cbAsioDrivers.Items.Add(driver);
            }
            if (cbAsioDrivers.Items.Count > 0)
            {
                for (int i = 0; i < asioDrivers.Count; i++)
                {
                    if (asioDrivers[i].Contains("Focusrite USB"))
                        cbAsioDrivers.SelectedIndex = i;
                }
            }
            cbAsioDrivers.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rect = this.ClientRectangle;

            // Уменьшаем прямоугольник, чтобы рамка не обрезалась
            rect.Inflate(-1, -1);

            using (GraphicsPath path = GetRoundedRectPath(rect, borderRadius))
            {
                this.Region = new Region(path);

                // Градиентная заливка
                using (LinearGradientBrush brush = new LinearGradientBrush(
                    rect,
                    Color.FromArgb(39, 41, 49),
                    Color.FromArgb(25, 30, 40),
                    LinearGradientMode.ForwardDiagonal))
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    e.Graphics.FillPath(brush, path);
                }

                // Пользовательская рамка
                using (Pen borderPen = new Pen(borderColor, borderThickness))
                {
                    e.Graphics.DrawPath(borderPen, path);
                }
            }
        }

        private GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {
            int diameter = radius * 2;
            GraphicsPath path = new GraphicsPath();

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();

            return path;
        }

        // Чтобы можно было перетаскивать форму мышью
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                NativeMethods.ReleaseCapture();
                NativeMethods.SendMessage(this.Handle, 0xA1, 0x2, 0); // WM_NCLBUTTONDOWN, HTCAPTION
            }
        }

        private static class NativeMethods
        {
            [System.Runtime.InteropServices.DllImport("user32.dll")]
            public static extern bool ReleaseCapture();

            [System.Runtime.InteropServices.DllImport("user32.dll")]
            public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        }
        private void Pereferences_Form_Load(object sender, EventArgs e)
        {

        }
    }
}
