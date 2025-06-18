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
            rGBFrameToolStripMenuItem = new ToolStripMenuItem();
            enabledToolStripMenuItem = new ToolStripMenuItem();
            disabledToolStripMenuItem = new ToolStripMenuItem();
            redrawdebugToolStripMenuItem = new ToolStripMenuItem();
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
            knobASOU = new dfsa.ui.controls.DistortionKnob();
            knobVROU = new dfsa.ui.controls.DistortionKnob();
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
            panel6 = new Panel();
            label18 = new Label();
            label19 = new Label();
            label20 = new Label();
            distortionKnob1 = new dfsa.ui.controls.DistortionKnob();
            distortionKnob2 = new dfsa.ui.controls.DistortionKnob();
            panel3 = new Panel();
            label17 = new Label();
            label14 = new Label();
            knobPitchMix = new dfsa.ui.controls.DistortionKnob();
            label15 = new Label();
            label16 = new Label();
            knobWindowSize = new dfsa.ui.controls.DistortionKnob();
            knobShift = new dfsa.ui.controls.DistortionKnob();
            panel4 = new Panel();
            panel5 = new Panel();
            panel7 = new Panel();
            panel8 = new Panel();
            label33 = new Label();
            label32 = new Label();
            label23 = new Label();
            label31 = new Label();
            label30 = new Label();
            label29 = new Label();
            label21 = new Label();
            label24 = new Label();
            label25 = new Label();
            eqBand2_4k = new TweakFX.ui.controls.EqualizerBandControl();
            eqBand1k = new TweakFX.ui.controls.EqualizerBandControl();
            eqBand400 = new TweakFX.ui.controls.EqualizerBandControl();
            eqBand150 = new TweakFX.ui.controls.EqualizerBandControl();
            label26 = new Label();
            label27 = new Label();
            label28 = new Label();
            eqBand60 = new TweakFX.ui.controls.EqualizerBandControl();
            label22 = new Label();
            EQMixKnob = new dfsa.ui.controls.DistortionKnob();
            panel1.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            panelDelay.SuspendLayout();
            panel2.SuspendLayout();
            panelDistortion.SuspendLayout();
            panel6.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            panel7.SuspendLayout();
            panel8.SuspendLayout();
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
            panel1.Size = new Size(1433, 36);
            panel1.TabIndex = 0;
            // 
            // pnlMinimize
            // 
            pnlMinimize.BackColor = Color.Transparent;
            pnlMinimize.BackgroundImage = (Image)resources.GetObject("pnlMinimize.BackgroundImage");
            pnlMinimize.BackgroundImageLayout = ImageLayout.Center;
            pnlMinimize.Dock = DockStyle.Right;
            pnlMinimize.Location = new Point(1361, 0);
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
            pnlClose.Location = new Point(1397, 0);
            pnlClose.Name = "pnlClose";
            pnlClose.Size = new Size(36, 36);
            pnlClose.TabIndex = 20;
            pnlClose.Click += pnlClose_Click;
            pnlClose.MouseDown += pnlClose_MouseDown;
            pnlClose.MouseEnter += pnlClose_MouseEnter;
            pnlClose.MouseLeave += pnlClose_MouseLeave;
            pnlClose.MouseUp += pnlClose_MouseUp;
            // 
            // lbLeaf
            // 
            lbLeaf.AutoSize = true;
            lbLeaf.Font = new Font("Wasted", 36F, FontStyle.Bold, GraphicsUnit.Point);
            lbLeaf.ForeColor = Color.White;
            lbLeaf.Location = new Point(3, 4);
            lbLeaf.Name = "lbLeaf";
            lbLeaf.Size = new Size(126, 58);
            lbLeaf.TabIndex = 5;
            lbLeaf.Text = "Leaf";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.White;
            label4.Location = new Point(18, 478);
            label4.Name = "label4";
            label4.Size = new Size(117, 25);
            label4.TabIndex = 9;
            label4.Text = "ASIO Output";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(24, 24);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { presetToolStripMenuItem, styleToolStripMenuItem, rGBFrameToolStripMenuItem, redrawdebugToolStripMenuItem, pereferencesToolStripMenuItem, exitToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(159, 136);
            // 
            // presetToolStripMenuItem
            // 
            presetToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { saveToolStripMenuItem, loadToolStripMenuItem });
            presetToolStripMenuItem.Name = "presetToolStripMenuItem";
            presetToolStripMenuItem.Size = new Size(158, 22);
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
            styleToolStripMenuItem.Size = new Size(158, 22);
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
            // rGBFrameToolStripMenuItem
            // 
            rGBFrameToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { enabledToolStripMenuItem, disabledToolStripMenuItem });
            rGBFrameToolStripMenuItem.Name = "rGBFrameToolStripMenuItem";
            rGBFrameToolStripMenuItem.Size = new Size(158, 22);
            rGBFrameToolStripMenuItem.Text = "RGB Frame";
            // 
            // enabledToolStripMenuItem
            // 
            enabledToolStripMenuItem.Checked = true;
            enabledToolStripMenuItem.CheckState = CheckState.Checked;
            enabledToolStripMenuItem.Name = "enabledToolStripMenuItem";
            enabledToolStripMenuItem.Size = new Size(119, 22);
            enabledToolStripMenuItem.Text = "Enabled";
            enabledToolStripMenuItem.Click += enabledToolStripMenuItem_Click;
            // 
            // disabledToolStripMenuItem
            // 
            disabledToolStripMenuItem.Name = "disabledToolStripMenuItem";
            disabledToolStripMenuItem.Size = new Size(119, 22);
            disabledToolStripMenuItem.Text = "Disabled";
            disabledToolStripMenuItem.Click += disabledToolStripMenuItem_Click;
            // 
            // redrawdebugToolStripMenuItem
            // 
            redrawdebugToolStripMenuItem.Name = "redrawdebugToolStripMenuItem";
            redrawdebugToolStripMenuItem.Size = new Size(158, 22);
            redrawdebugToolStripMenuItem.Text = "Redraw (debug)";
            redrawdebugToolStripMenuItem.Click += redrawdebugToolStripMenuItem_Click;
            // 
            // pereferencesToolStripMenuItem
            // 
            pereferencesToolStripMenuItem.Name = "pereferencesToolStripMenuItem";
            pereferencesToolStripMenuItem.Size = new Size(158, 22);
            pereferencesToolStripMenuItem.Text = "Pereferences";
            pereferencesToolStripMenuItem.Click += preferencesToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(158, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // oscilloscope
            // 
            oscilloscope.BackColor = Color.Gray;
            oscilloscope.Location = new Point(3, 3);
            oscilloscope.Name = "oscilloscope";
            oscilloscope.Size = new Size(387, 161);
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
            panelDelay.Location = new Point(288, 110);
            panelDelay.Name = "panelDelay";
            panelDelay.Size = new Size(322, 256);
            panelDelay.TabIndex = 13;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
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
            label6.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
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
            label7.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
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
            lbDelay.Font = new Font("Unispace", 27.7499962F, FontStyle.Bold, GraphicsUnit.Point);
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
            // knobASOU
            // 
            knobASOU.BackColor = Color.Transparent;
            knobASOU.Fade1 = Color.FromArgb(0, 238, 255);
            knobASOU.Fade2 = Color.FromArgb(0, 255, 51);
            knobASOU.Fade3 = Color.FromArgb(0, 99, 98);
            knobASOU.Location = new Point(24, 375);
            knobASOU.Name = "knobASOU";
            knobASOU.Size = new Size(110, 110);
            knobASOU.TabIndex = 14;
            knobASOU.Text = "distortionKnob5";
            knobASOU.Value = 0.5F;
            // 
            // knobVROU
            // 
            knobVROU.BackColor = Color.Transparent;
            knobVROU.Fade1 = Color.FromArgb(0, 238, 255);
            knobVROU.Fade2 = Color.FromArgb(0, 255, 51);
            knobVROU.Fade3 = Color.FromArgb(0, 99, 98);
            knobVROU.Location = new Point(264, 375);
            knobVROU.Name = "knobVROU";
            knobVROU.Size = new Size(110, 110);
            knobVROU.TabIndex = 16;
            knobVROU.Text = "distortionKnob5";
            knobVROU.Value = 0.5F;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label10.ForeColor = Color.White;
            label10.Location = new Point(252, 478);
            label10.Name = "label10";
            label10.Size = new Size(132, 25);
            label10.TabIndex = 15;
            label10.Text = "Virtual Output";
            // 
            // lbTweakFX
            // 
            lbTweakFX.AutoSize = true;
            lbTweakFX.Font = new Font("Wasted", 36F, FontStyle.Bold, GraphicsUnit.Point);
            lbTweakFX.ForeColor = Color.White;
            lbTweakFX.Location = new Point(1185, 4);
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
            knobAVMix.Location = new Point(140, 375);
            knobAVMix.Name = "knobAVMix";
            knobAVMix.Size = new Size(110, 110);
            knobAVMix.TabIndex = 19;
            knobAVMix.Text = "distortionKnob5";
            knobAVMix.Value = 1F;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label12.ForeColor = Color.White;
            label12.Location = new Point(147, 478);
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
            panel2.Location = new Point(616, 110);
            panel2.Name = "panel2";
            panel2.Size = new Size(407, 256);
            panel2.TabIndex = 15;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
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
            label8.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
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
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
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
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
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
            label11.Font = new Font("Unispace", 27.7499962F, FontStyle.Bold, GraphicsUnit.Point);
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
            lbDistortion.Font = new Font("Unispace", 27.7499962F, FontStyle.Bold, GraphicsUnit.Point);
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
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
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
            label5.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
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
            panelDistortion.Controls.Add(panel6);
            panelDistortion.Controls.Add(label5);
            panelDistortion.Controls.Add(label2);
            panelDistortion.Controls.Add(lbDistortion);
            panelDistortion.Controls.Add(knobThres);
            panelDistortion.Controls.Add(knobDist);
            panelDistortion.Location = new Point(7, 110);
            panelDistortion.Name = "panelDistortion";
            panelDistortion.Size = new Size(275, 256);
            panelDistortion.TabIndex = 11;
            // 
            // panel6
            // 
            panel6.BackColor = Color.FromArgb(25, 30, 40);
            panel6.BorderStyle = BorderStyle.FixedSingle;
            panel6.Controls.Add(label18);
            panel6.Controls.Add(label19);
            panel6.Controls.Add(label20);
            panel6.Controls.Add(distortionKnob1);
            panel6.Controls.Add(distortionKnob2);
            panel6.Location = new Point(-1, -1);
            panel6.Name = "panel6";
            panel6.Size = new Size(275, 256);
            panel6.TabIndex = 13;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label18.ForeColor = Color.White;
            label18.Location = new Point(166, 178);
            label18.Name = "label18";
            label18.Size = new Size(96, 25);
            label18.TabIndex = 12;
            label18.Text = "Threshold";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label19.ForeColor = Color.White;
            label19.Location = new Point(18, 178);
            label19.Name = "label19";
            label19.Size = new Size(95, 25);
            label19.TabIndex = 4;
            label19.Text = "Distortion";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Unispace", 27.7499962F, FontStyle.Bold, GraphicsUnit.Point);
            label20.ForeColor = Color.White;
            label20.Location = new Point(14, 20);
            label20.Name = "label20";
            label20.Size = new Size(249, 44);
            label20.TabIndex = 2;
            label20.Text = "Distortion";
            // 
            // distortionKnob1
            // 
            distortionKnob1.BackColor = Color.Transparent;
            distortionKnob1.Fade1 = Color.FromArgb(0, 238, 255);
            distortionKnob1.Fade2 = Color.FromArgb(0, 255, 51);
            distortionKnob1.Fade3 = Color.FromArgb(0, 99, 98);
            distortionKnob1.Location = new Point(163, 91);
            distortionKnob1.Name = "distortionKnob1";
            distortionKnob1.Size = new Size(100, 100);
            distortionKnob1.TabIndex = 7;
            distortionKnob1.Text = "distortionKnob4";
            distortionKnob1.Value = 0.1F;
            // 
            // distortionKnob2
            // 
            distortionKnob2.BackColor = Color.Transparent;
            distortionKnob2.Fade1 = Color.FromArgb(0, 238, 255);
            distortionKnob2.Fade2 = Color.FromArgb(0, 255, 51);
            distortionKnob2.Fade3 = Color.FromArgb(0, 99, 98);
            distortionKnob2.Location = new Point(13, 91);
            distortionKnob2.Name = "distortionKnob2";
            distortionKnob2.Size = new Size(100, 100);
            distortionKnob2.TabIndex = 6;
            distortionKnob2.Text = "distortionKnob3";
            distortionKnob2.Value = 0F;
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
            panel3.Location = new Point(7, 374);
            panel3.Name = "panel3";
            panel3.Size = new Size(334, 256);
            panel3.TabIndex = 13;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label17.ForeColor = Color.White;
            label17.Location = new Point(137, 177);
            label17.Name = "label17";
            label17.Size = new Size(43, 25);
            label17.TabIndex = 18;
            label17.Text = "Mix";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label14.ForeColor = Color.White;
            label14.Location = new Point(195, 178);
            label14.Name = "label14";
            label14.Size = new Size(121, 25);
            label14.TabIndex = 12;
            label14.Text = "Window Size";
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
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
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
            label16.Font = new Font("Unispace", 27.7499962F, FontStyle.Bold, GraphicsUnit.Point);
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
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(25, 30, 40);
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(oscilloscope);
            panel4.Controls.Add(knobVROU);
            panel4.Controls.Add(label10);
            panel4.Controls.Add(knobAVMix);
            panel4.Controls.Add(knobASOU);
            panel4.Controls.Add(label12);
            panel4.Controls.Add(label4);
            panel4.Location = new Point(1029, 110);
            panel4.Name = "panel4";
            panel4.Size = new Size(395, 520);
            panel4.TabIndex = 20;
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(25, 30, 40);
            panel5.BorderStyle = BorderStyle.FixedSingle;
            panel5.Controls.Add(lbTweakFX);
            panel5.Controls.Add(lbLeaf);
            panel5.Location = new Point(7, 40);
            panel5.Name = "panel5";
            panel5.Size = new Size(1417, 64);
            panel5.TabIndex = 15;
            // 
            // panel7
            // 
            panel7.BackColor = Color.FromArgb(25, 30, 40);
            panel7.BorderStyle = BorderStyle.FixedSingle;
            panel7.Controls.Add(panel8);
            panel7.Controls.Add(label22);
            panel7.Controls.Add(EQMixKnob);
            panel7.Location = new Point(347, 374);
            panel7.Name = "panel7";
            panel7.Size = new Size(676, 256);
            panel7.TabIndex = 14;
            panel7.Paint += panel7_Paint;
            // 
            // panel8
            // 
            panel8.BackColor = Color.FromArgb(25, 30, 40);
            panel8.BorderStyle = BorderStyle.FixedSingle;
            panel8.Controls.Add(label33);
            panel8.Controls.Add(label32);
            panel8.Controls.Add(label23);
            panel8.Controls.Add(label31);
            panel8.Controls.Add(label30);
            panel8.Controls.Add(label29);
            panel8.Controls.Add(label21);
            panel8.Controls.Add(label24);
            panel8.Controls.Add(label25);
            panel8.Controls.Add(eqBand2_4k);
            panel8.Controls.Add(eqBand1k);
            panel8.Controls.Add(eqBand400);
            panel8.Controls.Add(eqBand150);
            panel8.Controls.Add(label26);
            panel8.Controls.Add(label27);
            panel8.Controls.Add(label28);
            panel8.Controls.Add(eqBand60);
            panel8.Location = new Point(132, 3);
            panel8.Name = "panel8";
            panel8.Size = new Size(425, 248);
            panel8.TabIndex = 17;
            // 
            // label33
            // 
            label33.AutoSize = true;
            label33.Font = new Font("Unispace", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label33.ForeColor = Color.White;
            label33.Location = new Point(277, 201);
            label33.Name = "label33";
            label33.Size = new Size(43, 16);
            label33.TabIndex = 28;
            label33.Text = "2.4k";
            // 
            // label32
            // 
            label32.AutoSize = true;
            label32.Font = new Font("Unispace", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label32.ForeColor = Color.White;
            label32.Location = new Point(238, 201);
            label32.Name = "label32";
            label32.Size = new Size(25, 16);
            label32.TabIndex = 27;
            label32.Text = "1k";
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Font = new Font("Unispace", 27.7499962F, FontStyle.Bold, GraphicsUnit.Point);
            label23.ForeColor = Color.White;
            label23.Location = new Point(103, 16);
            label23.Name = "label23";
            label23.Size = new Size(226, 44);
            label23.TabIndex = 2;
            label23.Text = "Equalizer";
            // 
            // label31
            // 
            label31.AutoSize = true;
            label31.Font = new Font("Unispace", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label31.ForeColor = Color.White;
            label31.Location = new Point(189, 201);
            label31.Name = "label31";
            label31.Size = new Size(34, 16);
            label31.TabIndex = 26;
            label31.Text = "400";
            // 
            // label30
            // 
            label30.AutoSize = true;
            label30.Font = new Font("Unispace", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label30.ForeColor = Color.White;
            label30.Location = new Point(144, 201);
            label30.Name = "label30";
            label30.Size = new Size(34, 16);
            label30.TabIndex = 25;
            label30.Text = "150";
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.Font = new Font("Unispace", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label29.ForeColor = Color.White;
            label29.Location = new Point(103, 201);
            label29.Name = "label29";
            label29.Size = new Size(25, 16);
            label29.TabIndex = 24;
            label29.Text = "60";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Font = new Font("Unispace", 14F, FontStyle.Bold, GraphicsUnit.Point);
            label21.ForeColor = Color.White;
            label21.Location = new Point(326, 169);
            label21.Name = "label21";
            label21.Size = new Size(82, 23);
            label21.TabIndex = 23;
            label21.Text = "-12 dB";
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Font = new Font("Unispace", 14F, FontStyle.Bold, GraphicsUnit.Point);
            label24.ForeColor = Color.White;
            label24.Location = new Point(326, 58);
            label24.Name = "label24";
            label24.Size = new Size(82, 23);
            label24.TabIndex = 22;
            label24.Text = "+12 dB";
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Font = new Font("Unispace", 14F, FontStyle.Bold, GraphicsUnit.Point);
            label25.ForeColor = Color.White;
            label25.Location = new Point(326, 114);
            label25.Name = "label25";
            label25.Size = new Size(58, 23);
            label25.TabIndex = 21;
            label25.Text = "0 dB";
            // 
            // eqBand2_4k
            // 
            eqBand2_4k.BackColor = Color.FromArgb(25, 30, 40);
            eqBand2_4k.Location = new Point(278, 68);
            eqBand2_4k.MaxValue = 12F;
            eqBand2_4k.MinValue = -12F;
            eqBand2_4k.Name = "eqBand2_4k";
            eqBand2_4k.Size = new Size(39, 134);
            eqBand2_4k.TabIndex = 20;
            eqBand2_4k.Text = "equalizerBandControl5";
            eqBand2_4k.Value = 0F;
            // 
            // eqBand1k
            // 
            eqBand1k.BackColor = Color.FromArgb(25, 30, 40);
            eqBand1k.Location = new Point(233, 68);
            eqBand1k.MaxValue = 12F;
            eqBand1k.MinValue = -12F;
            eqBand1k.Name = "eqBand1k";
            eqBand1k.Size = new Size(39, 134);
            eqBand1k.TabIndex = 19;
            eqBand1k.Text = "equalizerBandControl4";
            eqBand1k.Value = 0F;
            // 
            // eqBand400
            // 
            eqBand400.BackColor = Color.FromArgb(25, 30, 40);
            eqBand400.Location = new Point(188, 68);
            eqBand400.MaxValue = 12F;
            eqBand400.MinValue = -12F;
            eqBand400.Name = "eqBand400";
            eqBand400.Size = new Size(39, 134);
            eqBand400.TabIndex = 18;
            eqBand400.Text = "equalizerBandControl3";
            eqBand400.Value = 0F;
            // 
            // eqBand150
            // 
            eqBand150.BackColor = Color.FromArgb(25, 30, 40);
            eqBand150.Location = new Point(143, 68);
            eqBand150.MaxValue = 12F;
            eqBand150.MinValue = -12F;
            eqBand150.Name = "eqBand150";
            eqBand150.Size = new Size(39, 134);
            eqBand150.TabIndex = 17;
            eqBand150.Text = "equalizerBandControl1";
            eqBand150.Value = 0F;
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Font = new Font("Unispace", 14F, FontStyle.Bold, GraphicsUnit.Point);
            label26.ForeColor = Color.White;
            label26.Location = new Point(44, 169);
            label26.Name = "label26";
            label26.Size = new Size(46, 23);
            label26.TabIndex = 16;
            label26.Text = "-12";
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Font = new Font("Unispace", 14F, FontStyle.Bold, GraphicsUnit.Point);
            label27.ForeColor = Color.White;
            label27.Location = new Point(44, 58);
            label27.Name = "label27";
            label27.Size = new Size(46, 23);
            label27.TabIndex = 15;
            label27.Text = "+12";
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Font = new Font("Unispace", 14F, FontStyle.Bold, GraphicsUnit.Point);
            label28.ForeColor = Color.White;
            label28.Location = new Point(68, 114);
            label28.Name = "label28";
            label28.Size = new Size(22, 23);
            label28.TabIndex = 14;
            label28.Text = "0";
            // 
            // eqBand60
            // 
            eqBand60.BackColor = Color.FromArgb(25, 30, 40);
            eqBand60.Location = new Point(98, 68);
            eqBand60.MaxValue = 12F;
            eqBand60.MinValue = -12F;
            eqBand60.Name = "eqBand60";
            eqBand60.Size = new Size(39, 134);
            eqBand60.TabIndex = 13;
            eqBand60.Text = "equalizerBandControl2";
            eqBand60.Value = 0F;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label22.ForeColor = Color.White;
            label22.Location = new Point(43, 178);
            label22.Name = "label22";
            label22.Size = new Size(43, 25);
            label22.TabIndex = 4;
            label22.Text = "Mix";
            // 
            // EQMixKnob
            // 
            EQMixKnob.BackColor = Color.Transparent;
            EQMixKnob.Fade1 = Color.FromArgb(0, 238, 255);
            EQMixKnob.Fade2 = Color.FromArgb(0, 255, 51);
            EQMixKnob.Fade3 = Color.FromArgb(0, 99, 98);
            EQMixKnob.Location = new Point(13, 91);
            EQMixKnob.Name = "EQMixKnob";
            EQMixKnob.Size = new Size(100, 100);
            EQMixKnob.TabIndex = 6;
            EQMixKnob.Text = "distortionKnob3";
            EQMixKnob.Value = 0F;
            // 
            // DistortionNeonPedal
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(21, 23, 31);
            ClientSize = new Size(1433, 642);
            ContextMenuStrip = contextMenuStrip1;
            Controls.Add(panel7);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panelDelay);
            Controls.Add(panelDistortion);
            Controls.Add(panel1);
            Controls.Add(panel4);
            Controls.Add(panel5);
            FormBorderStyle = FormBorderStyle.None;
            Name = "DistortionNeonPedal";
            Text = "DistortionNeonPedal";
            FormClosing += DistortionNeonPedal_FormClosing;
            Load += DistortionNeonPedal_Load;
            panel1.ResumeLayout(false);
            contextMenuStrip1.ResumeLayout(false);
            panelDelay.ResumeLayout(false);
            panelDelay.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panelDistortion.ResumeLayout(false);
            panelDistortion.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            ResumeLayout(false);
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
        private controls.DistortionKnob knobASOU;
        private controls.DistortionKnob knobVROU;
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
        private ToolStripMenuItem redrawdebugToolStripMenuItem;
        private ToolStripMenuItem rGBFrameToolStripMenuItem;
        private ToolStripMenuItem enabledToolStripMenuItem;
        private ToolStripMenuItem disabledToolStripMenuItem;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private Label label18;
        private Label label19;
        private Label label20;
        private controls.DistortionKnob distortionKnob1;
        private Panel panel7;
        private Label label22;
        private Label label23;
        private controls.DistortionKnob distortionKnob3;
        private controls.DistortionKnob EQMixKnob;
        private Panel panel8;
        private Label label21;
        private Label label24;
        private Label label25;
        private TweakFX.ui.controls.EqualizerBandControl eqBand2_4k;
        private TweakFX.ui.controls.EqualizerBandControl eqBand1k;
        private TweakFX.ui.controls.EqualizerBandControl eqBand400;
        private TweakFX.ui.controls.EqualizerBandControl eqBand150;
        private Label label26;
        private Label label27;
        private Label label28;
        private TweakFX.ui.controls.EqualizerBandControl eqBand60;
        private Label label29;
        private Label label33;
        private Label label32;
        private Label label31;
        private Label label30;
    }
}
