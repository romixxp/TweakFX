using System.Windows.Forms;
using System;
using NAudio.Wave;
using TweakFX.core;
using TweakFX.core.effects.distortion;
using TweakFX.ui;
using TweakFX.ui.controls;
using TweakFX.ui.controls.VisualAudio;
using TweakFX.ui.controls.unused;
using dfsa.ui.controls;
using System.Drawing.Drawing2D;
using System.Diagnostics;
using SkiaSharp.Views.Desktop;
using SkiaSharp;
using TweakFX.core.client_pereferences;


namespace dfsa.ui
{
    public partial class DistortionNeonPedal : Form
    {
        private bool isDragging = false;
        private Point offset;
        private Clipper _distortionEffect;
        AudioEngine engine;
        private System.Windows.Forms.Timer oscilloscopeTimer;
        private PresetManager _presetManager;
        private List<DistortionKnob> _distortionKnobs;
        private bool isFrameDrawing = true;
        private float hueOffset = 0f;
        private readonly Stopwatch stopwatch = new Stopwatch();
        private bool animationRunning = false;
        private readonly SKControl skControl = new SKControl();
        public DistortionNeonPedal()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.DoubleBuffered = true;

            skControl.Dock = DockStyle.Fill;
            skControl.PaintSurface += SkControl_PaintSurface;
            skControl.BackColor = Color.Black; // Прозрачность не работает — оставим фон, который не мешает
            this.Controls.Add(skControl);
            //skControl.BringToFront(); // Поверх всех контролов
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            stopwatch.Start();
            StartFrameAnimation();

        }
        private void SkControl_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            //MakeControlsTransparent(this);
            var canvas = e.Surface.Canvas;
            canvas.Clear(SKColors.Transparent);

            int width = e.Info.Width;
            int height = e.Info.Height;
            int thickness = 3;

            float time = (float)(stopwatch.ElapsedMilliseconds % 10000) / 10000f;
            float hueShift = (time * 360f) % 360f;

            // === Градиентный фон ===
            using (var bgPaint = new SKPaint())
            {
                var gradientColors = new[]
                {
            SKColor.FromHsv((hueShift + 0) % 360, 80, 15),
            SKColor.FromHsv((hueShift + 60) % 360, 80, 10)
        };
                var shader = SKShader.CreateLinearGradient(
                    new SKPoint(0, 0),
                    new SKPoint(width, height),
                    gradientColors,
                    null,
                    SKShaderTileMode.Clamp
                );
                bgPaint.Shader = shader;
                canvas.DrawRect(new SKRect(0, 0, width, height), bgPaint);
            }

            // === Рамка с переходом цвета ===
            using (var paint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                StrokeWidth = thickness,
                IsAntialias = true
            })
            {
                // Границы
                var points = new[]
                {
            new SKPoint(thickness, thickness),
            new SKPoint(width - thickness, thickness),           // top
            new SKPoint(width - thickness, height - thickness),  // right
            new SKPoint(thickness, height - thickness),          // bottom
            new SKPoint(thickness, thickness)                    // left
        };

                for (int i = 0; i < 4; i++)
                {
                    float hueStart = (hueShift + i * 90f) % 360;
                    float hueEnd = (hueShift + (i + 1) * 90f) % 360;

                    var shader = SKShader.CreateLinearGradient(
                        points[i],
                        points[i + 1],
                        new[]
                        {
                    SKColor.FromHsv(hueStart, 100, 100),
                    SKColor.FromHsv(hueEnd, 100, 100)
                        },
                        null,
                        SKShaderTileMode.Clamp
                    );

                    paint.Shader = shader;
                    canvas.DrawLine(points[i], points[i + 1], paint);
                }
            }
        }


        private SKColor SKColorFromHSV(double hue, double saturation, double value)
        {
            int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
            double f = hue / 60 - Math.Floor(hue / 60);

            value = value * 255;
            int v = Convert.ToInt32(value);
            int p = Convert.ToInt32(value * (1 - saturation));
            int q = Convert.ToInt32(value * (1 - f * saturation));
            int t = Convert.ToInt32(value * (1 - (1 - f) * saturation));

            return hi switch
            {
                0 => new SKColor((byte)v, (byte)t, (byte)p),
                1 => new SKColor((byte)q, (byte)v, (byte)p),
                2 => new SKColor((byte)p, (byte)v, (byte)t),
                3 => new SKColor((byte)p, (byte)q, (byte)v),
                4 => new SKColor((byte)t, (byte)p, (byte)v),
                _ => new SKColor((byte)v, (byte)p, (byte)q),
            };
        }

        private void topPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                offset = new Point(e.X, e.Y);
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

            //Delay
            knobDelay.Value = 0.5f;
            knobFeedback.Value = 0.2f;
            knobDelayMix.Value = 0.5f;
            engine.UpdDelayTime((int)(knobDelay.Value * 1000));
            engine.UpdFeedback(knobFeedback.Value);
            engine.UpdWetMix(knobDelayMix.Value);

            //Reverb
            knobDecay.Value = 0.1f;
            knobDamping.Value = 0.3f;
            knobPreDelay.Value = 0f;
            knobReverbMix.Value = 0.2f;
            engine.UpdDecay(knobDecay.Value * 70000);
            engine.UpdDamping(knobDamping.Value);
            engine.UpdPreDelay(knobPreDelay.Value * 1000);
            engine.UpdWetMixReverb(knobReverbMix.Value);

            //Pitch Shifter
            knobShift.Value = 0.5f;
            knobPitchMix.Value = 0f;
            knobWindowSize.Value = 0.5f;
            engine.UpdPitchShiftMix(knobPitchMix.Value);
            engine.UpdPitchShift(knobShift.Value);


            //Other
            knobVROU.Value = 1f;
            knobASOU.Value = 0f;
            knobAVMix.Value = 1f;
            engine.SetASIOOutputLevel(knobVROU.Value);
            engine.SetWASAPIOutputLevel(knobASOU.Value);
            engine.SetMix(knobAVMix.Value);
        }
        private void DistortionNeonPedal_Load(object sender, EventArgs e)
        {
            MakeControlsTransparent(this);
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

            #region Reverb

            knobDecay.ValueChanged += (s, e) => engine.UpdDecay(knobDecay.Value * 70000);
            knobReverbMix.ValueChanged += (s, e) => engine.UpdWetMixReverb(knobReverbMix.Value);
            knobDamping.ValueChanged += (s, e) => engine.UpdDamping(knobDamping.Value);
            knobPreDelay.ValueChanged += (s, e) => engine.UpdPreDelay(knobPreDelay.Value * 1000);

            #endregion

            #region Pitch Shifter

            knobPitchMix.ValueChanged += (s, e) => engine.UpdPitchShiftMix(knobPitchMix.Value);
            knobShift.ValueChanged += (s, e) => engine.UpdPitchShift(knobShift.Value);

            #endregion

            knobASOU.ValueChanged += (s, e) => engine.SetASIOOutputLevel(knobASOU.Value);
            knobVROU.ValueChanged += (s, e) =>
            {
                engine.SetWASAPIOutputLevel(knobVROU.Value);
                engine.UpdWetMix(knobDelayMix.Value * knobVROU.Value);
            };
            knobAVMix.ValueChanged += (s, e) => engine.SetMix(knobAVMix.Value);


            #endregion
            // engine.AddEffect(new MyReverb());
            // engine.AddEffect(new MyCompressor());
            oscilloscopeTimer = new System.Windows.Forms.Timer
            {
                Interval = 20
            };


            oscilloscopeTimer.Tick += (s, e) =>
            {
                float[] buffer = engine?.GetLatestBuffer();
                if (buffer != null && buffer.Length > 0)
                {
                    oscilloscope.UpdateBuffer(buffer);
                }
            };

            oscilloscopeTimer.Start();

            engine.Start();
            float[] audioData = new float[630];

            InitDefPreset(engine);

            _distortionKnobs = new List<DistortionKnob>();
            FindDistortionKnobs(this.Controls, _distortionKnobs);

            _presetManager = new PresetManager(_distortionKnobs);
        }
        private void FindDistortionKnobs(Control.ControlCollection controls, List<DistortionKnob> list)
        {
            foreach (Control control in controls)
            {
                if (control is DistortionKnob knob)
                {
                    list.Add(knob);
                }
                if (control.HasChildren)
                {
                    FindDistortionKnobs(control.Controls, list);
                }
            }
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
            //Pereferences_Form perForm = new();
            //perForm.Show();
            asioInput.ShowControlPanel();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            engine.Stop();
            Application.Exit();
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

        private void SavePresetWithDialog()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "TweakFX Preset (*.tfxp)|*.tfxp";
                saveFileDialog.Title = "Save Preset";
                saveFileDialog.DefaultExt = "tfxp";
                saveFileDialog.AddExtension = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _presetManager.SavePreset(saveFileDialog.FileName);
                }
            }
        }
        private void LoadPresetWithDialog()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "TweakFX Preset (*.tfxp)|*.tfxp";
                openFileDialog.Title = "Load Preset";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _presetManager.LoadPreset(openFileDialog.FileName);
                }
            }
        }
        private void SavePreset(string path) => _presetManager.SavePreset(path);
        private void LoadPreset(string path) => _presetManager.LoadPreset(path);
        private void DistortionNeonPedal_FormClosing(object sender, FormClosingEventArgs e) => engine?.Stop();
        private void pnlClose_Click(object sender, EventArgs e) => Application.Exit();
        private void pnlMinimize_MouseUp(object sender, MouseEventArgs e) => pnlMinimize.BackColor = Color.FromArgb(20, 255, 255, 255);
        private void pnlMinimize_MouseDown(object sender, MouseEventArgs e) => pnlMinimize.BackColor = Color.FromArgb(10, 255, 255, 255);
        private void pnlMinimize_MouseLeave(object sender, EventArgs e) => pnlMinimize.BackColor = Color.Transparent;
        private void pnlMinimize_MouseEnter(object sender, EventArgs e) => pnlMinimize.BackColor = Color.FromArgb(20, 255, 255, 255);
        private void pnlClose_MouseDown(object sender, MouseEventArgs e) => pnlClose.BackColor = Color.FromArgb(30, 255, 100, 100);
        private void pnlClose_MouseUp(object sender, MouseEventArgs e) => pnlClose.BackColor = Color.FromArgb(50, 255, 100, 100);
        private void pnlClose_MouseEnter(object sender, EventArgs e) => pnlClose.BackColor = Color.FromArgb(50, 255, 100, 100);
        private void pnlClose_MouseLeave(object sender, EventArgs e) => pnlClose.BackColor = Color.Transparent;
        private void pnlMinimize_Click(object sender, EventArgs e) => this.WindowState = FormWindowState.Minimized;
        private void saveToolStripMenuItem_Click(object sender, EventArgs e) => SavePresetWithDialog();
        private void loadToolStripMenuItem_Click(object sender, EventArgs e) => LoadPresetWithDialog();
        Color fade1 = Color.FromArgb(21, 25, 46);
        Color fade2 = Color.FromArgb(21, 23, 31);
        private bool isDrawing = false;
        private async void StartFrameAnimation()
        {
            if (animationRunning) return;
            animationRunning = true;

            while (!this.IsDisposed)
            {
                skControl.Invalidate(); // Обновляем Skia рамку
                await Task.Delay(16); // ~60 FPS
            }
        }

        private void DrawRainbowFrame()
        {
            try
            {
                using (Graphics g = this.CreateGraphics())
                using (Pen pen = new Pen(Color.Black, 1))
                {
                    Rectangle rect = this.ClientRectangle;

                    float step = 1f / (rect.Width * 2 + rect.Height * 2);
                    float timeElapsed = (float)stopwatch.ElapsedMilliseconds / 1000f;
                    float hue = (timeElapsed * 50f) % 360f;

                    float currentHue = hue;

                    Action<int, int, int, int> drawLine = (x1, y1, x2, y2) =>
                    {
                        pen.Color = ColorFromHSV(currentHue, 0.6f, 0.8f);
                        g.DrawLine(pen, x1, y1, x2, y2);
                        currentHue = (currentHue + step * 360) % 360;
                    };

                    // Верх
                    for (int x = 0; x < rect.Width; x++)
                        drawLine(x, 0, x, 2);

                    // Право
                    for (int y = 0; y < rect.Height; y++)
                        drawLine(rect.Width - 3, y, rect.Width, y);

                    // Низ
                    for (int x = rect.Width - 1; x >= 0; x--)
                        drawLine(x, rect.Height - 3, x, rect.Height);

                    // Лево
                    for (int y = rect.Height - 1; y >= 0; y--)
                        drawLine(0, y, 2, y);
                }
            }
            catch
            {
                // Игнорировать ошибки при отрисовке во время сворачивания и т.п.
            }
        }



        public static Color ColorFromHSV(double hue, double saturation, double value)
        {
            int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
            double f = hue / 60 - Math.Floor(hue / 60);

            value = value * 255;
            int v = Convert.ToInt32(value);
            int p = Convert.ToInt32(value * (1 - saturation));
            int q = Convert.ToInt32(value * (1 - f * saturation));
            int t = Convert.ToInt32(value * (1 - (1 - f) * saturation));

            return hi switch
            {
                0 => Color.FromArgb(v, t, p),
                1 => Color.FromArgb(q, v, p),
                2 => Color.FromArgb(p, v, t),
                3 => Color.FromArgb(p, q, v),
                4 => Color.FromArgb(t, p, v),
                _ => Color.FromArgb(v, p, q),
            };
        }


        private void MakeControlsTransparent(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is Label || control is DistortionKnob)
                {
                    control.BackColor = Color.Transparent;
                }
                if (control.HasChildren)
                {
                    MakeControlsTransparent(control);
                }
                Debug.WriteLine("Transparented: " + control.Name);
            }
        }
        private void MakeControlsRedrawed(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is Label)
                {
                    control.ForeColor = Color.Black;
                    control.BackColor = Color.Transparent;
                }
                else if (control is DistortionKnob knob)
                {
                    knob.Fade1 = Color.FromArgb(220, 220, 220);
                    knob.Fade2 = Color.FromArgb(255, 255, 255);
                    knob.Fade3 = Color.FromArgb(100, 100, 100);
                    MessageBox.Show($"{knob.Fade1}, {knob.Fade2}, {knob.Fade3}");
                    knob.Invalidate();
                    knob.Refresh();
                }
                fade1 = Color.FromArgb(255, 255, 255);
                fade2 = Color.FromArgb(220, 220, 220);
                if (control.HasChildren)
                {
                    MakeControlsTransparent(control);
                }
            }
            Invalidate();
        }
        private void sunsetDriveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frostySynthToolStripMenuItem.Checked = false;
            neonNightToolStripMenuItem.Checked = false;
            monoClassicToolStripMenuItem.Checked = false;
            sunsetDriveToolStripMenuItem.Checked = true;
        }
        private void frostySynthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sunsetDriveToolStripMenuItem.Checked = false;
            neonNightToolStripMenuItem.Checked = false;
            monoClassicToolStripMenuItem.Checked = false;
            frostySynthToolStripMenuItem.Checked = true;
        }
        private void neonNightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sunsetDriveToolStripMenuItem.Checked = false;
            frostySynthToolStripMenuItem.Checked = false;
            monoClassicToolStripMenuItem.Checked = false;
            neonNightToolStripMenuItem.Checked = true;
        }
        private void monoClassicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sunsetDriveToolStripMenuItem.Checked = false;
            frostySynthToolStripMenuItem.Checked = false;
            neonNightToolStripMenuItem.Checked = false;
            monoClassicToolStripMenuItem.Checked = true;
            MakeControlsRedrawed(this);
        }

        private void redrawdebugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void disabledToolStripMenuItem_Click(object sender, EventArgs e)
        {
            enabledToolStripMenuItem.Checked = false;
            disabledToolStripMenuItem.Checked = true;
            isFrameDrawing = false;
            this.Invalidate();
        }

        private void enabledToolStripMenuItem_Click(object sender, EventArgs e)
        {
            enabledToolStripMenuItem.Checked = true;
            disabledToolStripMenuItem.Checked = false;
            isFrameDrawing = true;
            this.Invalidate();
        }

    }
}
