namespace TweakFX.ui
{
    partial class AsioVisualConfig
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
            label2 = new Label();
            CBDrivers = new ComboBox();
            CBBufferSize = new ComboBox();
            label3 = new Label();
            CBSampleRate = new ComboBox();
            label4 = new Label();
            groupBox1 = new GroupBox();
            lbRTLat = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F);
            label2.Location = new Point(17, 22);
            label2.Name = "label2";
            label2.Size = new Size(67, 15);
            label2.TabIndex = 1;
            label2.Text = "ASIO Driver";
            // 
            // CBDrivers
            // 
            CBDrivers.FormattingEnabled = true;
            CBDrivers.Location = new Point(100, 19);
            CBDrivers.Name = "CBDrivers";
            CBDrivers.Size = new Size(170, 23);
            CBDrivers.TabIndex = 2;
            CBDrivers.SelectedIndexChanged += CBDrivers_SelectedIndexChanged;
            // 
            // CBBufferSize
            // 
            CBBufferSize.FormattingEnabled = true;
            CBBufferSize.Location = new Point(100, 43);
            CBBufferSize.Name = "CBBufferSize";
            CBBufferSize.Size = new Size(170, 23);
            CBBufferSize.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F);
            label3.Location = new Point(17, 46);
            label3.Name = "label3";
            label3.Size = new Size(62, 15);
            label3.TabIndex = 3;
            label3.Text = "Buffer Size";
            // 
            // CBSampleRate
            // 
            CBSampleRate.FormattingEnabled = true;
            CBSampleRate.Location = new Point(100, 68);
            CBSampleRate.Name = "CBSampleRate";
            CBSampleRate.Size = new Size(170, 23);
            CBSampleRate.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F);
            label4.Location = new Point(17, 71);
            label4.Name = "label4";
            label4.Size = new Size(72, 15);
            label4.TabIndex = 5;
            label4.Text = "Sample Rate";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lbRTLat);
            groupBox1.Controls.Add(CBSampleRate);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(CBDrivers);
            groupBox1.Controls.Add(CBBufferSize);
            groupBox1.Controls.Add(label3);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(279, 135);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "ASIO Streaming Settings";
            // 
            // lbRTLat
            // 
            lbRTLat.AutoSize = true;
            lbRTLat.Location = new Point(17, 98);
            lbRTLat.Name = "lbRTLat";
            lbRTLat.Size = new Size(113, 15);
            lbRTLat.TabIndex = 7;
            lbRTLat.Text = "Round-Trip Latency:";
            // 
            // AsioVisualConfig
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(304, 158);
            Controls.Add(groupBox1);
            Name = "AsioVisualConfig";
            Text = "AsioVisualConfig";
            Load += AsioVisualConfig_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label label2;
        private ComboBox CBDrivers;
        private ComboBox CBBufferSize;
        private Label label3;
        private ComboBox CBSampleRate;
        private Label label4;
        private GroupBox groupBox1;
        private Label lbRTLat;
    }
}