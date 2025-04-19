using System.Windows.Forms;
using System;
using NAudio.Wave;
using TweakFX.core;
using TweakFX.core.effects.distortion;
using TweakFX.ui;
using TweakFX.ui.controls;
using TweakFX.ui.controls.VisualAudio;
using TweakFX.ui.controls.unused;


namespace dfsa.ui
{
    public partial class DistortionNeonPedal : Form
    {
        private bool isDragging = false;
        private Point offset;
        private Clipper _distortionEffect;
        AudioEngine engine;
        private System.Windows.Forms.Timer oscilloscopeTimer;
        private System.Windows.Forms.Timer MagnitudeSpectrogramTimer;
        private SpectrogramControl spectrogram;
        public DistortionNeonPedal()
        {
            InitializeComponent();
            this.Text = "Draggable Top Panel Example";

            // Предположим, что панель topPanel добавлена через дизайнер
            // Пример: панель закреплена вверху и ее свойства установлены в дизайнере
            // topPanel.Dock = DockStyle.Top; // Убедитесь, что панель докируется к верху формы
            panel1.Cursor = Cursors.Default; // Установим курсор для перетаскивания

            spectrogram = new SpectrogramControl
            {
                Dock = DockStyle.Fill
            };
            Controls.Add(spectrogram);

        }

        private void topPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                offset = new Point(e.X, e.Y); // Сохраняем смещение мыши относительно панели
            }
        }

        private void topPanel_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

        private void topPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                // Смещаем форму на расстояние от начальной точки
                this.Location = new Point(this.Left + e.X - offset.X, this.Top + e.Y - offset.Y);
            }
        }
        private void DistortionNeonPedal_Load(object sender, EventArgs e)
        {
            // Привязываем события мыши к панели (если это не сделано в дизайнере)
            panel1.MouseDown += topPanel_MouseDown;
            panel1.MouseUp += topPanel_MouseUp;
            panel1.MouseMove += topPanel_MouseMove;
            var config = new AsioConfig
            {
                DriverName = "Focusrite USB ASIO",
                InputChannel = 0,
                OutputChannel = 0,
                SampleRate = 44100
            };
            engine = new AudioEngine(config);
            knobVol.Value = 0.5f;
            knobTone.Value = 0.5f;
            knobDist.Value = 0.5f;
            //_distortionEffect = new Clipper(distortionAmount: knobDist.Value, tone: knobTone.Value, volume: knobVol.Value);
            knobVol.ValueChanged += (s, e) =>
            {
                engine.UpdVol(knobVol.Value * 10);
            };
            knobTone.ValueChanged += (s, e) =>
            {
                engine.UpdThres(knobTone.Value);
            };
            knobDist.ValueChanged += (s, e) =>
            {
                engine.UpdDist(knobDist.Value * 10);
            };
            // Можно добавить эффекты
            // engine.AddEffect(new MyReverb());
            // engine.AddEffect(new MyCompressor());
            oscilloscopeTimer = new System.Windows.Forms.Timer
            {
                Interval = 20
            };          
            MagnitudeSpectrogramTimer = new System.Windows.Forms.Timer
            {
                Interval = 5
            };

            oscilloscopeTimer.Tick += (s, e) =>
            {
                float[] buffer = engine?.GetLatestBuffer(); // ты должен реализовать метод ниже в AudioEngine
                if (buffer != null && buffer.Length > 0)
                {
                    oscilloscope.UpdateBuffer(buffer);
                }
            };
            MagnitudeSpectrogramTimer.Tick += (s, e) =>
            {
                float[] buffer = engine?.GetLatestBuffer(); // ты должен реализовать метод ниже в AudioEngine
                if (buffer != null && buffer.Length > 0)
                {
                    spectrogram.AddFrame(buffer);
                }
            };
            oscilloscopeTimer.Start();
            MagnitudeSpectrogramTimer.Start();
            engine.Start();
            float[] audioData = new float[630];
            Random random = new();
            for (int i = 0; i < audioData.Length; i++)
            {
                audioData[i] = random.Next(-100, 100) / 100f; // Пример синусоиды
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //AsioVisualConfig virtconf = new AsioVisualConfig();
            /*if (virtconf.ShowDialog() == DialogResult.OK)
            {
                string driverName = virtconf.SelectedDriver;
                int sampleRate = virtconf.SelectedSampleRate;
                int bufferSize = virtconf.SelectedBufferSize;

                engine.Restart(driverName, sampleRate, bufferSize);
            }*/
            AsioInput asioInput = new AsioInput();
            asioInput.ShowControlPanel();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            engine.Stop();
            Application.Exit();
        }

        private void knobVol_Click(object sender, EventArgs e)
        {

        }

        private void DistortionNeonPedal_FormClosing(object sender, FormClosingEventArgs e)
        {
            engine?.Stop();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void GenerateTestData()
        {
            /*          float[] magnitudes = new float[512];
                      double t = DateTime.Now.TimeOfDay.TotalSeconds;
                      for (int i = 0; i < magnitudes.Length; i++)
                      {
                          magnitudes[i] = (float)(0.5 * (Math.Sin(i * 0.05 + t * 5) + 1));
                      }  */

    
        }


    }
}
