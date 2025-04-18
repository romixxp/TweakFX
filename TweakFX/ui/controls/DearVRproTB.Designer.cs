namespace dfsa
{
    partial class DearVRproTB
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            panel2 = new Panel();
            textBox1 = new TextBox();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(5, 66, 67);
            panel2.Controls.Add(textBox1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(69, 28);
            panel2.TabIndex = 4;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(5, 47, 49);
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBox1.ForeColor = Color.FromArgb(77, 225, 210);
            textBox1.Location = new Point(1, 1);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(67, 26);
            textBox1.TabIndex = 2;
            textBox1.Text = "-96.0";
            // 
            // DearVRproTB
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel2);
            Name = "DearVRproTB";
            Size = new Size(69, 28);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private TextBox textBox1;
    }
}
