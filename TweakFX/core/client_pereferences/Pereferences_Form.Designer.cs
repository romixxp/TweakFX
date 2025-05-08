namespace TweakFX.core.client_pereferences
{
    partial class Pereferences_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cbAsioDrivers = new ComboBox();
            panel1 = new Panel();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // cbAsioDrivers
            // 
            cbAsioDrivers.FormattingEnabled = true;
            cbAsioDrivers.Location = new Point(3, 24);
            cbAsioDrivers.Name = "cbAsioDrivers";
            cbAsioDrivers.Size = new Size(182, 23);
            cbAsioDrivers.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(150, 25, 30, 40);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(cbAsioDrivers);
            panel1.ForeColor = SystemColors.ControlText;
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 226);
            panel1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(90, 21);
            label1.TabIndex = 0;
            label1.Text = "Asio Driver";
            // 
            // Pereferences_Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Name = "Pereferences_Form";
            Text = "Pereferences_Form";
            Load += Pereferences_Form_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ComboBox cbAsioDrivers;
        private Panel panel1;
        private Label label1;
    }
}