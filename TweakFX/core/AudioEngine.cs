using System;
using NAudio.Wave;
using System.Windows.Forms; // Добавь это для MessageBox

namespace TweakFX.core
{
    public class AudioEngine
    {
        private AsioOut _asioOut;
        private string _driverName;
        private int _sampleRate;
        private int _bufferSize;

        public AudioEngine(string driverName, int sampleRate, int bufferSize)
        {
            _driverName = driverName;
            _sampleRate = sampleRate;
            _bufferSize = bufferSize;
        }

        public int SelectedSampleRate => _sampleRate;
        public int SelectedBufferSize => _bufferSize;

        public void Start()
        {
            try
            {
                if (_asioOut != null)
                {
                    _asioOut.Stop();
                    _asioOut.Dispose();
                }

                _asioOut = new AsioOut(_driverName);
                _asioOut.InitRecordAndPlayback(null, 2, _sampleRate); // 2 канала на выход
                _asioOut.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка инициализации ASIO драйвера: {ex.Message}");
            }
        }

        public void Restart(string driverName, int sampleRate, int bufferSize)
        {
            Stop();
            _driverName = driverName;
            _sampleRate = sampleRate;
            _bufferSize = bufferSize;
            Start();
        }

        public void Stop()
        {
            if (_asioOut != null)
            {
                _asioOut.Stop();
                _asioOut.Dispose();
                _asioOut = null;
            }
        }
    }
}