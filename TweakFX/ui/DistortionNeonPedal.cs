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
        public DistortionNeonPedal()
        {
            InitializeComponent();
            this.Text = "Draggable Top Panel Example";

            // Предположим, что панель topPanel добавлена через дизайнер
            // Пример: панель закреплена вверху и ее свойства установлены в дизайнере
            // topPanel.Dock = DockStyle.Top; // Убедитесь, что панель докируется к верху формы
            panel1.Cursor = Cursors.Default; // Установим курсор для перетаскивания


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

        public void InitDefPreset(AudioEngine engine)
        {
            //Distortion
            knobThres.Value = 0.7f;
            knobDist.Value = 0.2f;
            engine.UpdThres(knobThres.Value * 5);
            engine.UpdDist(knobDist.Value * 10);

            knobDelay.Value = 0.5f;
            knobFeedback.Value = 0.2f;
            knobDelayMix.Value = 0.5f;
            engine.UpdDelayTime((int)(knobDelay.Value * 1000));
            engine.UpdFeedback(knobFeedback.Value);
            engine.UpdWetMix(knobDelayMix.Value);

            //Other
            knobOut.Value = 1 / 2f;
            knobIn.Value = 1 / 2f;
            knobAVMix.Value = 1f;
            engine.SetOutVol(knobOut.Value);
            engine.SetInVol(knobIn.Value);
            engine.SetMix(knobAVMix.Value);
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

            //_distortionEffect = new Clipper(distortionAmount: knobDist.Value, tone: knobTone.Value, volume: knobVol.Value);
            #region ValueChanged

            #region Distortion

            knobThres.ValueChanged += (s, e) => engine.UpdThres(knobThres.Value * 5);
            knobDist.ValueChanged += (s, e) => engine.UpdDist(knobDist.Value * 10);


            #endregion

            #region Delay

            knobDelay.ValueChanged += (s, e) => engine.UpdDelayTime((int)(knobDelay.Value * 1000));
            knobFeedback.ValueChanged += (s, e) => engine.UpdFeedback(knobFeedback.Value);
            knobDelayMix.ValueChanged += (s, e) => engine.UpdWetMix(knobDelayMix.Value);

            #endregion

            knobIn.ValueChanged += (s, e) => engine.SetInVol(knobIn.Value);
            knobOut.ValueChanged += (s, e) =>
            {
                engine.SetOutVol(knobOut.Value);
                engine.UpdWetMix(knobDelayMix.Value * knobOut.Value);
            };
            knobAVMix.ValueChanged += (s, e) => engine.SetMix(knobAVMix.Value);


            #endregion
            // Можно добавить эффекты
            // engine.AddEffect(new MyReverb());
            // engine.AddEffect(new MyCompressor());
            oscilloscopeTimer = new System.Windows.Forms.Timer
            {
                Interval = 20
            };


            oscilloscopeTimer.Tick += (s, e) =>
            {
                float[] buffer = engine?.GetLatestBuffer(); // ты должен реализовать метод ниже в AudioEngine
                if (buffer != null && buffer.Length > 0)
                {
                    oscilloscope.UpdateBuffer(buffer);
                }
            };

            oscilloscopeTimer.Start();

            engine.Start();
            float[] audioData = new float[630];
            Random random = new();
            for (int i = 0; i < audioData.Length; i++)
            {
                audioData[i] = random.Next(-100, 100) / 100f; // Пример синусоиды
            }
            InitDefPreset(engine);

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



        private void DistortionNeonPedal_FormClosing(object sender, FormClosingEventArgs e)
        {
            engine?.Stop();
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
