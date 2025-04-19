namespace dfsa.ui
{
    partial class DistortionNeonPedal
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
            components = new System.ComponentModel.Container();
            panel1 = new Panel();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            knobDist = new controls.DistortionKnob();
            knobTone = new controls.DistortionKnob();
            knobVol = new controls.DistortionKnob();
            label4 = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            presetToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            loadToolStripMenuItem = new ToolStripMenuItem();
            pereferencesToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(20, 255, 255, 255);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(618, 30);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.ForeColor = Color.White;
            label1.Location = new Point(31, 120);
            label1.Name = "label1";
            label1.Size = new Size(143, 40);
            label1.TabIndex = 2;
            label1.Text = "Distortion";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.ForeColor = Color.White;
            label2.Location = new Point(148, 120);
            label2.Name = "label2";
            label2.Size = new Size(142, 40);
            label2.TabIndex = 4;
            label2.Text = "Threshold";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(240, 78);
            label3.Name = "label3";
            label3.Size = new Size(366, 82);
            label3.TabIndex = 5;
            label3.Text = "Tweak FX";
            // 
            // knobDist
            // 
            knobDist.Location = new Point(26, 36);
            knobDist.Name = "knobDist";
            knobDist.Size = new Size(100, 100);
            knobDist.TabIndex = 6;
            knobDist.Text = "distortionKnob3";
            knobDist.Value = 0F;
            // 
            // knobTone
            // 
            knobTone.Location = new Point(132, 56);
            knobTone.Name = "knobTone";
            knobTone.Size = new Size(80, 80);
            knobTone.TabIndex = 7;
            knobTone.Text = "distortionKnob4";
            knobTone.Value = 0F;
            // 
            // knobVol
            // 
            knobVol.Location = new Point(488, 56);
            knobVol.Name = "knobVol";
            knobVol.Size = new Size(80, 80);
            knobVol.TabIndex = 8;
            knobVol.Text = "distortionKnob5";
            knobVol.Value = 0.5F;
            knobVol.Click += knobVol_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label4.ForeColor = Color.White;
            label4.Location = new Point(491, 120);
            label4.Name = "label4";
            label4.Size = new Size(113, 40);
            label4.TabIndex = 9;
            label4.Text = "Volume";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(24, 24);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { presetToolStripMenuItem, pereferencesToolStripMenuItem, exitToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(183, 100);
            // 
            // presetToolStripMenuItem
            // 
            presetToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { saveToolStripMenuItem, loadToolStripMenuItem });
            presetToolStripMenuItem.Name = "presetToolStripMenuItem";
            presetToolStripMenuItem.Size = new Size(182, 32);
            presetToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(153, 34);
            saveToolStripMenuItem.Text = "Save";
            // 
            // loadToolStripMenuItem
            // 
            loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            loadToolStripMenuItem.Size = new Size(153, 34);
            loadToolStripMenuItem.Text = "Load";
            // 
            // pereferencesToolStripMenuItem
            // 
            pereferencesToolStripMenuItem.Name = "pereferencesToolStripMenuItem";
            pereferencesToolStripMenuItem.Size = new Size(182, 32);
            pereferencesToolStripMenuItem.Text = "Pereferences";
            pereferencesToolStripMenuItem.Click += preferencesToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(182, 32);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // DistortionNeonPedal
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(21, 23, 31);
            ClientSize = new Size(618, 170);
            ContextMenuStrip = contextMenuStrip1;
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(knobVol);
            Controls.Add(knobTone);
            Controls.Add(label1);
            Controls.Add(knobDist);
            Controls.Add(label3);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "DistortionNeonPedal";
            Text = "DistortionNeonPedal";
            FormClosing += DistortionNeonPedal_FormClosing;
            Load += DistortionNeonPedal_Load;
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private controls.DistortionKnob distortionKnob1;
        private Label label1;
        private Label label2;
        private controls.DistortionKnob distortionKnob2;
        private Label label3;
        private controls.DistortionKnob knobDist;
        private controls.DistortionKnob knobTone;
        private controls.DistortionKnob knobVol;
        private Label label4;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem pereferencesToolStripMenuItem;
        private ToolStripMenuItem presetToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem loadToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
    }
}
