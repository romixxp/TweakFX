using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;

namespace TweakFX.core.ui
{
    public partial class AsioVisualConfig : Form
    {
        public AsioVisualConfig()
        {
            InitializeComponent();
            LoadAudioSettings();
        }

        private void AsioVisualConfig_Load(object sender, EventArgs e)
        {

        }

        private void ShowDeviceInfo()
        {
            if (CBDrivers.SelectedItem == null) return;

            try
            {
                var driverName = CBDrivers.SelectedItem.ToString();
//                int sampleRate = SelectedSampleRate;
//                int bufferSize = SelectedBufferSize;

                // ASIO обычно подразумевает: латентность = буфер (сэмплы) * 2 (на input+output)
//                int totalLatencySamples = bufferSize * 2;
//                double totalLatencyMs = (double)totalLatencySamples / sampleRate * 1000.0;

//                lbRTLat.Text = $"Latency: {totalLatencyMs:0.00} ms ({totalLatencySamples} samples)";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при получении информации о драйвере: {ex.Message}");
            }
        }
        private void LoadAudioSettings()
        {/*
            // 1. Список ASIO драйверов
            
            // 2. Список стандартных sample rates
            CBSampleRate.Items.AddRange(new object[]
            {
                44100, 48000, 88200, 96000, 176400, 192000
            });

            // 3. Размеры буфера
            CBBufferSize.Items.AddRange(new object[]
            {
                64, 128, 256, 512, 1024, 2048
            });

            // Выбрать первый элемент по умолчанию
            if (CBDrivers.Items.Count > 0) CBDrivers.SelectedIndex = 0;
            CBSampleRate.SelectedIndex = 0; // 44100
            CBBufferSize.SelectedIndex = 3; // 512
        */
            CBDrivers.Items.AddRange(AsioOut.GetDriverNames().ToArray());
            bool _isDriverFound = false;
            for (int i = 0; i < CBDrivers.Items.Count; i++)
            {
                string driverName = CBDrivers.Items[i].ToString();
                if (driverName.Contains(_cvars.ASIO_name))
                {
                    CBDrivers.SelectedIndex = i;
                    _isDriverFound = true;
                    break;
                }
            }
            if (!_isDriverFound)
            {
                if (CBDrivers.Items.Count > 0) 
                    CBDrivers.SelectedIndex = 0;
            }
        }

        private void CBDrivers_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowDeviceInfo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.asioInput.ShowControlPanel();
            
        }

        public string SelectedDriver => CBDrivers.SelectedItem?.ToString();
        /*public int SelectedSampleRate => (int)CBSampleRate.SelectedItem;
        public int SelectedBufferSize => (int)CBBufferSize.SelectedItem;
    */
    }

}
