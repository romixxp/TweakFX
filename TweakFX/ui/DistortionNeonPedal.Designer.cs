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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DistortionNeonPedal));
            panel1 = new Panel();
            pnlMinimize = new Panel();
            pnlClose = new Panel();
            lbLeaf = new Label();
            label4 = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            presetToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            loadToolStripMenuItem = new ToolStripMenuItem();
            styleToolStripMenuItem = new ToolStripMenuItem();
            neonNightToolStripMenuItem = new ToolStripMenuItem();
            sunsetDriveToolStripMenuItem = new ToolStripMenuItem();
            frostySynthToolStripMenuItem = new ToolStripMenuItem();
            monoClassicToolStripMenuItem = new ToolStripMenuItem();
            pereferencesToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            oscilloscope = new TweakFX.ui.controls.VisualAudio.Oscilloscope();
            panelDelay = new Panel();
            label9 = new Label();
            label6 = new Label();
            label7 = new Label();
            lbDelay = new Label();
            knobFeedback = new dfsa.ui.controls.DistortionKnob();
            knobDelay = new dfsa.ui.controls.DistortionKnob();
            knobDelayMix = new dfsa.ui.controls.DistortionKnob();
            knobIn = new dfsa.ui.controls.DistortionKnob();
            knobOut = new dfsa.ui.controls.DistortionKnob();
            label10 = new Label();
            lbTweakFX = new Label();
            knobAVMix = new dfsa.ui.controls.DistortionKnob();
            label12 = new Label();
            knobDecay = new dfsa.ui.controls.DistortionKnob();
            panel2 = new Panel();
            label13 = new Label();
            knobDamping = new dfsa.ui.controls.DistortionKnob();
            label8 = new Label();
            label1 = new Label();
            label3 = new Label();
            label11 = new Label();
            knobPreDelay = new dfsa.ui.controls.DistortionKnob();
            knobReverbMix = new dfsa.ui.controls.DistortionKnob();
            knobDist = new dfsa.ui.controls.DistortionKnob();
            knobThres = new dfsa.ui.controls.DistortionKnob();
            lbDistortion = new Label();
            label2 = new Label();
            label5 = new Label();
            panelDistortion = new Panel();
            panel3 = new Panel();
            label14 = new Label();
            label15 = new Label();
            label16 = new Label();
            knobWindowSize = new dfsa.ui.controls.DistortionKnob();
            knobShift = new dfsa.ui.controls.DistortionKnob();
            label17 = new Label();
            knobPitchMix = new dfsa.ui.controls.DistortionKnob();
            panel1.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            panelDelay.SuspendLayout();
            panel2.SuspendLayout();
            panelDistortion.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(20, 255, 255, 255);
            panel1.Controls.Add(pnlMinimize);
            panel1.Controls.Add(pnlClose);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1774, 36);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // pnlMinimize
            // 
            pnlMinimize.BackColor = Color.Transparent;
            pnlMinimize.BackgroundImage = (Image)resources.GetObject("pnlMinimize.BackgroundImage");
            pnlMinimize.BackgroundImageLayout = ImageLayout.Center;
            pnlMinimize.Dock = DockStyle.Right;
            pnlMinimize.Location = new Point(1702, 0);
            pnlMinimize.Name = "pnlMinimize";
            pnlMinimize.Size = new Size(36, 36);
            pnlMinimize.TabIndex = 21;
            pnlMinimize.Click += pnlMinimize_Click;
            pnlMinimize.MouseDown += pnlMinimize_MouseDown;
            pnlMinimize.MouseEnter += pnlMinimize_MouseEnter;
            pnlMinimize.MouseLeave += pnlMinimize_MouseLeave;
            pnlMinimize.MouseUp += pnlMinimize_MouseUp;
            // 
            // pnlClose
            // 
            pnlClose.BackColor = Color.Transparent;
            pnlClose.BackgroundImage = (Image)resources.GetObject("pnlClose.BackgroundImage");
            pnlClose.BackgroundImageLayout = ImageLayout.Center;
            pnlClose.Dock = DockStyle.Right;
            pnlClose.Location = new Point(1738, 0);
            pnlClose.Name = "pnlClose";
            pnlClose.Size = new Size(36, 36);
            pnlClose.TabIndex = 20;
            pnlClose.Click += pnlClose_Click;
            pnlClose.Paint += pnlClose_Paint;
            pnlClose.MouseDown += pnlClose_MouseDown;
            pnlClose.MouseEnter += pnlClose_MouseEnter;
            pnlClose.MouseLeave += pnlClose_MouseLeave;
            pnlClose.MouseUp += pnlClose_MouseUp;
            // 
            // lbLeaf
            // 
            lbLeaf.AutoSize = true;
            lbLeaf.Font = new Font("Wasted", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbLeaf.ForeColor = Color.White;
            lbLeaf.Location = new Point(12, 48);
            lbLeaf.Name = "lbLeaf";
            lbLeaf.Size = new Size(126, 58);
            lbLeaf.TabIndex = 5;
            lbLeaf.Text = "Leaf";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label4.ForeColor = Color.White;
            label4.Location = new Point(1374, 340);
            label4.Name = "label4";
            label4.Size = new Size(125, 25);
            label4.TabIndex = 9;
            label4.Text = "Input Volume";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(24, 24);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { presetToolStripMenuItem, styleToolStripMenuItem, pereferencesToolStripMenuItem, exitToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(142, 92);
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
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // loadToolStripMenuItem
            // 
            loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            loadToolStripMenuItem.Size = new Size(100, 22);
            loadToolStripMenuItem.Text = "Load";
            loadToolStripMenuItem.Click += loadToolStripMenuItem_Click;
            // 
            // styleToolStripMenuItem
            // 
            styleToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { neonNightToolStripMenuItem, sunsetDriveToolStripMenuItem, frostySynthToolStripMenuItem, monoClassicToolStripMenuItem });
            styleToolStripMenuItem.Name = "styleToolStripMenuItem";
            styleToolStripMenuItem.Size = new Size(141, 22);
            styleToolStripMenuItem.Text = "Style";
            // 
            // neonNightToolStripMenuItem
            // 
            neonNightToolStripMenuItem.Checked = true;
            neonNightToolStripMenuItem.CheckState = CheckState.Checked;
            neonNightToolStripMenuItem.Name = "neonNightToolStripMenuItem";
            neonNightToolStripMenuItem.Size = new Size(145, 22);
            neonNightToolStripMenuItem.Text = "Neon Night";
            neonNightToolStripMenuItem.Click += neonNightToolStripMenuItem_Click;
            // 
            // sunsetDriveToolStripMenuItem
            // 
            sunsetDriveToolStripMenuItem.Name = "sunsetDriveToolStripMenuItem";
            sunsetDriveToolStripMenuItem.Size = new Size(145, 22);
            sunsetDriveToolStripMenuItem.Text = "Sunset Drive";
            sunsetDriveToolStripMenuItem.Click += sunsetDriveToolStripMenuItem_Click;
            // 
            // frostySynthToolStripMenuItem
            // 
            frostySynthToolStripMenuItem.Name = "frostySynthToolStripMenuItem";
            frostySynthToolStripMenuItem.Size = new Size(145, 22);
            frostySynthToolStripMenuItem.Text = "Frosty Synth";
            frostySynthToolStripMenuItem.Click += frostySynthToolStripMenuItem_Click;
            // 
            // monoClassicToolStripMenuItem
            // 
            monoClassicToolStripMenuItem.Name = "monoClassicToolStripMenuItem";
            monoClassicToolStripMenuItem.Size = new Size(145, 22);
            monoClassicToolStripMenuItem.Text = "Mono Classic";
            monoClassicToolStripMenuItem.Click += monoClassicToolStripMenuItem_Click;
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
            oscilloscope.Location = new Point(1374, 109);
            oscilloscope.Name = "oscilloscope";
            oscilloscope.Size = new Size(385, 109);
            oscilloscope.TabIndex = 10;
            oscilloscope.Text = "oscilloscope1";
            // 
            // panelDelay
            // 
            panelDelay.BackColor = Color.FromArgb(25, 30, 40);
            panelDelay.BorderStyle = BorderStyle.FixedSingle;
            panelDelay.Controls.Add(label9);
            panelDelay.Controls.Add(label6);
            panelDelay.Controls.Add(label7);
            panelDelay.Controls.Add(lbDelay);
            panelDelay.Controls.Add(knobFeedback);
            panelDelay.Controls.Add(knobDelay);
            panelDelay.Controls.Add(knobDelayMix);
            panelDelay.Location = new Point(293, 109);
            panelDelay.Name = "panelDelay";
            panelDelay.Size = new Size(322, 256);
            panelDelay.TabIndex = 13;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label9.ForeColor = Color.White;
            label9.Location = new Point(137, 177);
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
            label6.Location = new Point(210, 178);
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
            label7.Location = new Point(35, 178);
            label7.Name = "label7";
            label7.Size = new Size(59, 25);
            label7.TabIndex = 4;
            label7.Text = "Delay";
            // 
            // lbDelay
            // 
            lbDelay.AutoSize = true;
            lbDelay.Font = new Font("Unispace", 27.7499962F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbDelay.ForeColor = Color.White;
            lbDelay.Location = new Point(96, 20);
            lbDelay.Name = "lbDelay";
            lbDelay.Size = new Size(134, 44);
            lbDelay.TabIndex = 2;
            lbDelay.Text = "Delay";
            // 
            // knobFeedback
            // 
            knobFeedback.BackColor = Color.Transparent;
            knobFeedback.Fade1 = Color.FromArgb(0, 238, 255);
            knobFeedback.Fade2 = Color.FromArgb(0, 255, 51);
            knobFeedback.Fade3 = Color.FromArgb(0, 99, 98);
            knobFeedback.Location = new Point(205, 91);
            knobFeedback.Name = "knobFeedback";
            knobFeedback.Size = new Size(100, 100);
            knobFeedback.TabIndex = 7;
            knobFeedback.Text = "distortionKnob4";
            knobFeedback.Value = 0.1F;
            // 
            // knobDelay
            // 
            knobDelay.BackColor = Color.Transparent;
            knobDelay.Fade1 = Color.FromArgb(0, 238, 255);
            knobDelay.Fade2 = Color.FromArgb(0, 255, 51);
            knobDelay.Fade3 = Color.FromArgb(0, 99, 98);
            knobDelay.Location = new Point(13, 91);
            knobDelay.Name = "knobDelay";
            knobDelay.Size = new Size(100, 100);
            knobDelay.TabIndex = 6;
            knobDelay.Text = "distortionKnob3";
            knobDelay.Value = 0F;
            // 
            // knobDelayMix
            // 
            knobDelayMix.BackColor = Color.Transparent;
            knobDelayMix.Fade1 = Color.FromArgb(0, 238, 255);
            knobDelayMix.Fade2 = Color.FromArgb(0, 255, 51);
            knobDelayMix.Fade3 = Color.FromArgb(0, 99, 98);
            knobDelayMix.Location = new Point(119, 111);
            knobDelayMix.Name = "knobDelayMix";
            knobDelayMix.Size = new Size(80, 80);
            knobDelayMix.TabIndex = 14;
            knobDelayMix.Text = "distortionKnob5";
            knobDelayMix.Value = 0.5F;
            // 
            // knobIn
            // 
            knobIn.BackColor = Color.Transparent;
            knobIn.Fade1 = Color.FromArgb(0, 238, 255);
            knobIn.Fade2 = Color.FromArgb(0, 255, 51);
            knobIn.Fade3 = Color.FromArgb(0, 99, 98);
            knobIn.Location = new Point(1383, 227);
            knobIn.Name = "knobIn";
            knobIn.Size = new Size(110, 110);
            knobIn.TabIndex = 14;
            knobIn.Text = "distortionKnob5";
            knobIn.Value = 0.5F;
            // 
            // knobOut
            // 
            knobOut.BackColor = Color.Transparent;
            knobOut.Fade1 = Color.FromArgb(0, 238, 255);
            knobOut.Fade2 = Color.FromArgb(0, 255, 51);
            knobOut.Fade3 = Color.FromArgb(0, 99, 98);
            knobOut.Location = new Point(1635, 227);
            knobOut.Name = "knobOut";
            knobOut.Size = new Size(110, 110);
            knobOut.TabIndex = 16;
            knobOut.Text = "distortionKnob5";
            knobOut.Value = 0.5F;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label10.ForeColor = Color.White;
            label10.Location = new Point(1619, 340);
            label10.Name = "label10";
            label10.Size = new Size(140, 25);
            label10.TabIndex = 15;
            label10.Text = "Output Volume";
            // 
            // lbTweakFX
            // 
            lbTweakFX.AutoSize = true;
            lbTweakFX.Font = new Font("Wasted", 36F, FontStyle.Bold);
            lbTweakFX.ForeColor = Color.White;
            lbTweakFX.Location = new Point(1531, 39);
            lbTweakFX.Name = "lbTweakFX";
            lbTweakFX.Size = new Size(227, 58);
            lbTweakFX.TabIndex = 17;
            lbTweakFX.Text = "Tweak FX";
            // 
            // knobAVMix
            // 
            knobAVMix.BackColor = Color.Transparent;
            knobAVMix.Fade1 = Color.FromArgb(0, 238, 255);
            knobAVMix.Fade2 = Color.FromArgb(0, 255, 51);
            knobAVMix.Fade3 = Color.FromArgb(0, 99, 98);
            knobAVMix.Location = new Point(1509, 227);
            knobAVMix.Name = "knobAVMix";
            knobAVMix.Size = new Size(110, 110);
            knobAVMix.TabIndex = 19;
            knobAVMix.Text = "distortionKnob5";
            knobAVMix.Value = 1F;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label12.ForeColor = Color.White;
            label12.Location = new Point(1516, 340);
            label12.Name = "label12";
            label12.Size = new Size(95, 25);
            label12.TabIndex = 18;
            label12.Text = "Effect Mix";
            // 
            // knobDecay
            // 
            knobDecay.BackColor = Color.Transparent;
            knobDecay.Fade1 = Color.FromArgb(0, 238, 255);
            knobDecay.Fade2 = Color.FromArgb(0, 255, 51);
            knobDecay.Fade3 = Color.FromArgb(0, 99, 98);
            knobDecay.Location = new Point(12, 91);
            knobDecay.Name = "knobDecay";
            knobDecay.Size = new Size(100, 100);
            knobDecay.TabIndex = 15;
            knobDecay.Text = "distortionKnob4";
            knobDecay.Value = 0.1F;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(25, 30, 40);
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(label13);
            panel2.Controls.Add(knobDamping);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(knobDecay);
            panel2.Controls.Add(label11);
            panel2.Controls.Add(knobPreDelay);
            panel2.Controls.Add(knobReverbMix);
            panel2.Location = new Point(621, 109);
            panel2.Name = "panel2";
            panel2.Size = new Size(407, 256);
            panel2.TabIndex = 15;
            panel2.Paint += panel2_Paint;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label13.ForeColor = Color.White;
            label13.Location = new Point(230, 178);
            label13.Name = "label13";
            label13.Size = new Size(89, 25);
            label13.TabIndex = 16;
            label13.Text = "Damping";
            // 
            // knobDamping
            // 
            knobDamping.BackColor = Color.Transparent;
            knobDamping.Fade1 = Color.FromArgb(0, 238, 255);
            knobDamping.Fade2 = Color.FromArgb(0, 255, 51);
            knobDamping.Fade3 = Color.FromArgb(0, 99, 98);
            knobDamping.Location = new Point(224, 91);
            knobDamping.Name = "knobDamping";
            knobDamping.Size = new Size(100, 100);
            knobDamping.TabIndex = 17;
            knobDamping.Text = "distortionKnob4";
            knobDamping.Value = 0.1F;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label8.ForeColor = Color.White;
            label8.Location = new Point(32, 178);
            label8.Name = "label8";
            label8.Size = new Size(63, 25);
            label8.TabIndex = 4;
            label8.Text = "Decay";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.ForeColor = Color.White;
            label1.Location = new Point(343, 177);
            label1.Name = "label1";
            label1.Size = new Size(43, 25);
            label1.TabIndex = 13;
            label1.Text = "Mix";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.ForeColor = Color.White;
            label3.Location = new Point(120, 178);
            label3.Name = "label3";
            label3.Size = new Size(95, 25);
            label3.TabIndex = 12;
            label3.Text = "Pre-Delay";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Unispace", 27.7499962F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.ForeColor = Color.White;
            label11.Location = new Point(131, 20);
            label11.Name = "label11";
            label11.Size = new Size(157, 44);
            label11.TabIndex = 2;
            label11.Text = "Reverb";
            // 
            // knobPreDelay
            // 
            knobPreDelay.BackColor = Color.Transparent;
            knobPreDelay.Fade1 = Color.FromArgb(0, 238, 255);
            knobPreDelay.Fade2 = Color.FromArgb(0, 255, 51);
            knobPreDelay.Fade3 = Color.FromArgb(0, 99, 98);
            knobPreDelay.Location = new Point(118, 91);
            knobPreDelay.Name = "knobPreDelay";
            knobPreDelay.Size = new Size(100, 100);
            knobPreDelay.TabIndex = 7;
            knobPreDelay.Text = "distortionKnob4";
            knobPreDelay.Value = 0.1F;
            // 
            // knobReverbMix
            // 
            knobReverbMix.BackColor = Color.Transparent;
            knobReverbMix.Fade1 = Color.FromArgb(0, 238, 255);
            knobReverbMix.Fade2 = Color.FromArgb(0, 255, 51);
            knobReverbMix.Fade3 = Color.FromArgb(0, 99, 98);
            knobReverbMix.Location = new Point(325, 111);
            knobReverbMix.Name = "knobReverbMix";
            knobReverbMix.Size = new Size(80, 80);
            knobReverbMix.TabIndex = 14;
            knobReverbMix.Text = "distortionKnob5";
            knobReverbMix.Value = 0.5F;
            // 
            // knobDist
            // 
            knobDist.BackColor = Color.Transparent;
            knobDist.Fade1 = Color.FromArgb(0, 238, 255);
            knobDist.Fade2 = Color.FromArgb(0, 255, 51);
            knobDist.Fade3 = Color.FromArgb(0, 99, 98);
            knobDist.Location = new Point(13, 91);
            knobDist.Name = "knobDist";
            knobDist.Size = new Size(100, 100);
            knobDist.TabIndex = 6;
            knobDist.Text = "distortionKnob3";
            knobDist.Value = 0F;
            // 
            // knobThres
            // 
            knobThres.BackColor = Color.Transparent;
            knobThres.Fade1 = Color.FromArgb(0, 238, 255);
            knobThres.Fade2 = Color.FromArgb(0, 255, 51);
            knobThres.Fade3 = Color.FromArgb(0, 99, 98);
            knobThres.Location = new Point(163, 91);
            knobThres.Name = "knobThres";
            knobThres.Size = new Size(100, 100);
            knobThres.TabIndex = 7;
            knobThres.Text = "distortionKnob4";
            knobThres.Value = 0.1F;
            // 
            // lbDistortion
            // 
            lbDistortion.AutoSize = true;
            lbDistortion.Font = new Font("Unispace", 27.7499962F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbDistortion.ForeColor = Color.White;
            lbDistortion.Location = new Point(14, 20);
            lbDistortion.Name = "lbDistortion";
            lbDistortion.Size = new Size(249, 44);
            lbDistortion.TabIndex = 2;
            lbDistortion.Text = "Distortion";
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
            // panelDistortion
            // 
            panelDistortion.BackColor = Color.FromArgb(25, 30, 40);
            panelDistortion.BorderStyle = BorderStyle.FixedSingle;
            panelDistortion.Controls.Add(label5);
            panelDistortion.Controls.Add(label2);
            panelDistortion.Controls.Add(lbDistortion);
            panelDistortion.Controls.Add(knobThres);
            panelDistortion.Controls.Add(knobDist);
            panelDistortion.Location = new Point(12, 109);
            panelDistortion.Name = "panelDistortion";
            panelDistortion.Size = new Size(275, 256);
            panelDistortion.TabIndex = 11;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(25, 30, 40);
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(label17);
            panel3.Controls.Add(label14);
            panel3.Controls.Add(knobPitchMix);
            panel3.Controls.Add(label15);
            panel3.Controls.Add(label16);
            panel3.Controls.Add(knobWindowSize);
            panel3.Controls.Add(knobShift);
            panel3.Location = new Point(1034, 109);
            panel3.Name = "panel3";
            panel3.Size = new Size(334, 256);
            panel3.TabIndex = 13;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label14.ForeColor = Color.White;
            label14.Location = new Point(195, 178);
            label14.Name = "label14";
            label14.Size = new Size(121, 25);
            label14.TabIndex = 12;
            label14.Text = "Window Size";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label15.ForeColor = Color.White;
            label15.Location = new Point(39, 177);
            label15.Name = "label15";
            label15.Size = new Size(50, 25);
            label15.TabIndex = 4;
            label15.Text = "Shift";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Unispace", 27.7499962F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label16.ForeColor = Color.White;
            label16.Location = new Point(11, 20);
            label16.Name = "label16";
            label16.Size = new Size(318, 44);
            label16.TabIndex = 2;
            label16.Text = "Pitch Shifter";
            // 
            // knobWindowSize
            // 
            knobWindowSize.BackColor = Color.Transparent;
            knobWindowSize.Fade1 = Color.FromArgb(0, 238, 255);
            knobWindowSize.Fade2 = Color.FromArgb(0, 255, 51);
            knobWindowSize.Fade3 = Color.FromArgb(0, 99, 98);
            knobWindowSize.Location = new Point(205, 91);
            knobWindowSize.Name = "knobWindowSize";
            knobWindowSize.Size = new Size(100, 100);
            knobWindowSize.TabIndex = 7;
            knobWindowSize.Text = "distortionKnob4";
            knobWindowSize.Value = 0.1F;
            // 
            // knobShift
            // 
            knobShift.BackColor = Color.Transparent;
            knobShift.Fade1 = Color.FromArgb(0, 238, 255);
            knobShift.Fade2 = Color.FromArgb(0, 255, 51);
            knobShift.Fade3 = Color.FromArgb(0, 99, 98);
            knobShift.Location = new Point(13, 91);
            knobShift.Name = "knobShift";
            knobShift.Size = new Size(100, 100);
            knobShift.TabIndex = 6;
            knobShift.Text = "distortionKnob3";
            knobShift.Value = 0F;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label17.ForeColor = Color.White;
            label17.Location = new Point(137, 177);
            label17.Name = "label17";
            label17.Size = new Size(43, 25);
            label17.TabIndex = 18;
            label17.Text = "Mix";
            // 
            // knobPitchMix
            // 
            knobPitchMix.BackColor = Color.Transparent;
            knobPitchMix.Fade1 = Color.FromArgb(0, 238, 255);
            knobPitchMix.Fade2 = Color.FromArgb(0, 255, 51);
            knobPitchMix.Fade3 = Color.FromArgb(0, 99, 98);
            knobPitchMix.Location = new Point(119, 111);
            knobPitchMix.Name = "knobPitchMix";
            knobPitchMix.Size = new Size(80, 80);
            knobPitchMix.TabIndex = 19;
            knobPitchMix.Text = "distortionKnob5";
            knobPitchMix.Value = 0.5F;
            // 
            // DistortionNeonPedal
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(21, 23, 31);
            ClientSize = new Size(1774, 381);
            ContextMenuStrip = contextMenuStrip1;
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(knobAVMix);
            Controls.Add(label12);
            Controls.Add(lbTweakFX);
            Controls.Add(knobOut);
            Controls.Add(label10);
            Controls.Add(knobIn);
            Controls.Add(panelDelay);
            Controls.Add(panelDistortion);
            Controls.Add(oscilloscope);
            Controls.Add(label4);
            Controls.Add(lbLeaf);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "DistortionNeonPedal";
            Text = "DistortionNeonPedal";
            FormClosing += DistortionNeonPedal_FormClosing;
            Load += DistortionNeonPedal_Load;
            Paint += DistortionNeonPedal_Paint;
            panel1.ResumeLayout(false);
            contextMenuStrip1.ResumeLayout(false);
            panelDelay.ResumeLayout(false);
            panelDelay.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panelDistortion.ResumeLayout(false);
            panelDistortion.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private controls.DistortionKnob knobDelayMix;
        private controls.DistortionKnob distortionKnob2;
        private Label lbLeaf;
        private Label label4;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem pereferencesToolStripMenuItem;
        private ToolStripMenuItem presetToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem loadToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private TweakFX.ui.controls.VisualAudio.Oscilloscope oscilloscope;
        private Panel panelDelay;
        private Label label6;
        private Label label7;
        private Label lbDelay;
        private controls.DistortionKnob knobFeedback;
        private controls.DistortionKnob knobDelay;
        private Label label9;
        private controls.DistortionKnob knobIn;
        private controls.DistortionKnob knobOut;
        private Label label10;
        private Label lbTweakFX;
        private controls.DistortionKnob knobAVMix;
        private Label label12;
        private Panel pnlClose;
        private Panel pnlMinimize;
        private ToolStripMenuItem styleToolStripMenuItem;
        private ToolStripMenuItem neonNightToolStripMenuItem;
        private ToolStripMenuItem sunsetDriveToolStripMenuItem;
        private ToolStripMenuItem frostySynthToolStripMenuItem;
        private ToolStripMenuItem monoClassicToolStripMenuItem;
        private controls.DistortionKnob knobDecay;
        private Panel panel2;
        private Label label1;
        private Label label3;
        private Label label8;
        private Label label11;
        private controls.DistortionKnob knobPreDelay;
        private controls.DistortionKnob knobReverbMix;
        private Label label13;
        private controls.DistortionKnob knobDamping;
        private controls.DistortionKnob knobDist;
        private controls.DistortionKnob knobThres;
        private Label lbDistortion;
        private Label label2;
        private Label label5;
        private Panel panelDistortion;
        private Panel panel3;
        private Label label14;
        private Label label15;
        private Label label16;
        private controls.DistortionKnob knobWindowSize;
        private controls.DistortionKnob knobShift;
        private Label label17;
        private controls.DistortionKnob knobPitchMix;
    }
}
