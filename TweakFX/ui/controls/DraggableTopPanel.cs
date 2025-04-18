using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dfsa.ui.controls
{
    using System;
    using System.Windows.Forms;

    public class DraggableTopPanel : Panel
    {
        private bool isDragging = false;
        private Point offset;

        public DraggableTopPanel()
        {
            this.Dock = DockStyle.Top;  // Панель будет прикреплена к верхней части формы
            this.Height = 30;  // Высота панели
            this.BackColor = System.Drawing.Color.Gray;  // Цвет панели
            this.Cursor = Cursors.SizeAll;  // Курсор изменится на "перетаскивание"
        }

        // Перехватываем событие мыши при нажатии на панель
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                offset = new Point(e.X, e.Y);  // Сохраняем позицию курсора относительно панели
            }
        }

        // Перехватываем событие мыши при отпускании кнопки мыши
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            isDragging = false;
        }

        // Перехватываем событие мыши при движении мыши
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (isDragging)
            {
                // Смещаем форму относительно текущего положения мыши
                Form parentForm = this.Parent as Form;
                if (parentForm != null)
                {
                    parentForm.Location = new Point(parentForm.Left + e.X - offset.X, parentForm.Top + e.Y - offset.Y);
                }
            }
        }
    }
}
