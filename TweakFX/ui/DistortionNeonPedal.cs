using NAudio.Wave;
using TweakFX.core;
using TweakFX.ui;

namespace dfsa.ui
{
    public partial class DistortionNeonPedal : Form
    {
        private bool isDragging = false;
        private Point offset;
        private BufferedWaveProvider buffer;
        private float[] floatBuffer;
        private AudioEngine _audioEngine;
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
        private void DistortionNeonPedal_Load(object sender, EventArgs e)
        {
            // Привязываем события мыши к панели (если это не сделано в дизайнере)
            panel1.MouseDown += topPanel_MouseDown;
            panel1.MouseUp += topPanel_MouseUp;
            panel1.MouseMove += topPanel_MouseMove;
            string driverName = "Focusrite USB ASIO"; // Здесь можешь брать из настроек
            int sampleRate = 44100;             // Здесь тоже можно брать из настроек
            int bufferSize = 512;

            _audioEngine = new AudioEngine(driverName, sampleRate, bufferSize);
            _audioEngine.Start();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AsioVisualConfig virtconf = new AsioVisualConfig();
            if (virtconf.ShowDialog() == DialogResult.OK)
            {
                string driverName = virtconf.SelectedDriver;
                int sampleRate = virtconf.SelectedSampleRate;
                int bufferSize = virtconf.SelectedBufferSize;

                _audioEngine.Restart(driverName, sampleRate, bufferSize);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void knobVol_Click(object sender, EventArgs e)
        {

        }

        private void DistortionNeonPedal_FormClosing(object sender, FormClosingEventArgs e)
        {
            _audioEngine?.Stop();
        }

    }
}
