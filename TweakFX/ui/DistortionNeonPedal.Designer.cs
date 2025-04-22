using TweakFX.ui.controls.unused;

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
            knobDist = new dfsa.ui.controls.DistortionKnob();
            knobThres = new dfsa.ui.controls.DistortionKnob();
            knobVol = new dfsa.ui.controls.DistortionKnob();
            label4 = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            presetToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            loadToolStripMenuItem = new ToolStripMenuItem();
            pereferencesToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            oscilloscope = new TweakFX.ui.controls.VisualAudio.Oscilloscope();
            panel2 = new Panel();
            label5 = new Label();
            panel3 = new Panel();
            label9 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            knobFeedback = new dfsa.ui.controls.DistortionKnob();
            knobDelay = new dfsa.ui.controls.DistortionKnob();
            knobDelayMix = new dfsa.ui.controls.DistortionKnob();
            contextMenuStrip1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(20, 255, 255, 255);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1291, 30);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Unispace", 27.7499962F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(14, 20);
            label1.Name = "label1";
            label1.Size = new Size(249, 44);
            label1.TabIndex = 2;
            label1.Text = "Distortion";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.ForeColor = Color.White;
            label2.Location = new Point(18, 178);
            label2.Name = "label2";
            label2.Size = new Size(95, 25);
            label2.TabIndex = 4;
            label2.Text = "Distortion";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Wasted", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(12, 36);
            label3.Name = "label3";
            label3.Size = new Size(1264, 58);
            label3.TabIndex = 5;
            label3.Text = "Leaf                                                    Tweak FX";
            // 
            // knobDist
            // 
            knobDist.Location = new Point(13, 91);
            knobDist.Name = "knobDist";
            knobDist.Size = new Size(100, 100);
            knobDist.TabIndex = 6;
            knobDist.Text = "distortionKnob3";
            knobDist.Value = 0F;
            // 
            // knobThres
            // 
            knobThres.Location = new Point(163, 91);
            knobThres.Name = "knobThres";
            knobThres.Size = new Size(100, 100);
            knobThres.TabIndex = 7;
            knobThres.Text = "distortionKnob4";
            knobThres.Value = 0.1F;
            // 
            // knobVol
            // 
            knobVol.Location = new Point(269, 425);
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
            label4.Location = new Point(272, 489);
            label4.Name = "label4";
            label4.Size = new Size(76, 25);
            label4.TabIndex = 9;
            label4.Text = "Volume";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(24, 24);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { presetToolStripMenuItem, pereferencesToolStripMenuItem, exitToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(142, 70);
            // 
            // presetToolStripMenuItem
            // 
            presetToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { saveToolStripMenuItem, loadToolStripMenuItem });
            presetToolStripMenuItem.Name = "presetToolStripMenuItem";
            presetToolStripMenuItem.Size = new Size(141, 22);
            presetToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(100, 22);
            saveToolStripMenuItem.Text = "Save";
            // 
            // loadToolStripMenuItem
            // 
            loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            loadToolStripMenuItem.Size = new Size(100, 22);
            loadToolStripMenuItem.Text = "Load";
            // 
            // pereferencesToolStripMenuItem
            // 
            pereferencesToolStripMenuItem.Name = "pereferencesToolStripMenuItem";
            pereferencesToolStripMenuItem.Size = new Size(141, 22);
            pereferencesToolStripMenuItem.Text = "Pereferences";
            pereferencesToolStripMenuItem.Click += preferencesToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(141, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // oscilloscope
            // 
            oscilloscope.BackColor = Color.Gray;
            oscilloscope.Location = new Point(31, 392);
            oscilloscope.Name = "oscilloscope";
            oscilloscope.Size = new Size(232, 113);
            oscilloscope.TabIndex = 10;
            oscilloscope.Text = "oscilloscope1";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(25, 30, 40);
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(knobThres);
            panel2.Controls.Add(knobDist);
            panel2.Location = new Point(12, 97);
            panel2.Name = "panel2";
            panel2.Size = new Size(275, 256);
            panel2.TabIndex = 11;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label5.ForeColor = Color.White;
            label5.Location = new Point(166, 178);
            label5.Name = "label5";
            label5.Size = new Size(96, 25);
            label5.TabIndex = 12;
            label5.Text = "Threshold";
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(25, 30, 40);
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(label9);
            panel3.Controls.Add(label6);
            panel3.Controls.Add(label7);
            panel3.Controls.Add(label8);
            panel3.Controls.Add(knobFeedback);
            panel3.Controls.Add(knobDelay);
            panel3.Controls.Add(knobDelayMix);
            panel3.Location = new Point(293, 97);
            panel3.Name = "panel3";
            panel3.Size = new Size(275, 256);
            panel3.TabIndex = 13;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label9.ForeColor = Color.White;
            label9.Location = new Point(115, 228);
            label9.Name = "label9";
            label9.Size = new Size(43, 25);
            label9.TabIndex = 13;
            label9.Text = "Mix";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label6.ForeColor = Color.White;
            label6.Location = new Point(168, 178);
            label6.Name = "label6";
            label6.Size = new Size(91, 25);
            label6.TabIndex = 12;
            label6.Text = "Feedback";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label7.ForeColor = Color.White;
            label7.Location = new Point(33, 178);
            label7.Name = "label7";
            label7.Size = new Size(59, 25);
            label7.TabIndex = 4;
            label7.Text = "Delay";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Unispace", 27.7499962F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.White;
            label8.Location = new Point(74, 20);
            label8.Name = "label8";
            label8.Size = new Size(134, 44);
            label8.TabIndex = 2;
            label8.Text = "Delay";
            // 
            // knobFeedback
            // 
            knobFeedback.Location = new Point(163, 91);
            knobFeedback.Name = "knobFeedback";
            knobFeedback.Size = new Size(100, 100);
            knobFeedback.TabIndex = 7;
            knobFeedback.Text = "distortionKnob4";
            knobFeedback.Value = 0.1F;
            // 
            // knobDelay
            // 
            knobDelay.Location = new Point(13, 91);
            knobDelay.Name = "knobDelay";
            knobDelay.Size = new Size(100, 100);
            knobDelay.TabIndex = 6;
            knobDelay.Text = "distortionKnob3";
            knobDelay.Value = 0F;
            // 
            // knobDelayMix
            // 
            knobDelayMix.Location = new Point(97, 162);
            knobDelayMix.Name = "knobDelayMix";
            knobDelayMix.Size = new Size(80, 80);
            knobDelayMix.TabIndex = 14;
            knobDelayMix.Text = "distortionKnob5";
            knobDelayMix.Value = 0.5F;
            // 
            // DistortionNeonPedal
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(21, 23, 31);
            ClientSize = new Size(1291, 541);
            ContextMenuStrip = contextMenuStrip1;
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(oscilloscope);
            Controls.Add(label4);
            Controls.Add(knobVol);
            Controls.Add(label3);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "DistortionNeonPedal";
            Text = "DistortionNeonPedal";
            FormClosing += DistortionNeonPedal_FormClosing;
            Load += DistortionNeonPedal_Load;
            contextMenuStrip1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private controls.DistortionKnob knobDelayMix;
        private Label label1;
        private Label label2;
        private controls.DistortionKnob distortionKnob2;
        private Label label3;
        private controls.DistortionKnob knobDist;
        private controls.DistortionKnob knobThres;
        private controls.DistortionKnob knobVol;
        private Label label4;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem pereferencesToolStripMenuItem;
        private ToolStripMenuItem presetToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem loadToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private TweakFX.ui.controls.VisualAudio.Oscilloscope oscilloscope;
        private Panel panel2;
        private Label label5;
        private Panel panel3;
        private Label label6;
        private Label label7;
        private Label label8;
        private controls.DistortionKnob knobFeedback;
        private controls.DistortionKnob knobDelay;
        private Label label9;
    }
}
