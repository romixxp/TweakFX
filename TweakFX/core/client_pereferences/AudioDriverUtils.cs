using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TweakFX.core.client_pereferences
{
    using NAudio.Wave;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;

    public class AudioDriverUtils
    {
        // Метод для получения списка всех выходных аудиодрайверов
        public static List<string> GetWaveOutDrivers()
        {
            List<string> driverList = new List<string>();

            for (int i = 0; i < WaveOut.DeviceCount; i++)
            {
                driverList.Add(WaveOut.GetCapabilities(i).ProductName);
            }

            return driverList;
        }

        // Метод для получения списка доступных входных аудиодрайверов
        public static List<string> GetWaveInDrivers()
        {
            List<string> driverList = new List<string>();

            for (int i = 0; i < WaveIn.DeviceCount; i++)
            {
                driverList.Add(WaveIn.GetCapabilities(i).ProductName);
            }

            return driverList;
        }

        // Метод для вывода списка выходных драйверов в ComboBox
        public static void PopulateWaveOutComboBox(ComboBox comboBox)
        {
            comboBox.Items.Clear();
            var drivers = GetWaveOutDrivers();

            foreach (var driver in drivers)
            {
                comboBox.Items.Add(driver);
            }

            if (comboBox.Items.Count > 0)
            {
                comboBox.SelectedIndex = 0;
            }
        }

        // Метод для вывода списка входных драйверов в ComboBox
        public static void PopulateWaveInComboBox(ComboBox comboBox)
        {
            comboBox.Items.Clear();
            var drivers = GetWaveInDrivers();

            foreach (var driver in drivers)
            {
                comboBox.Items.Add(driver);
            }

            if (comboBox.Items.Count > 0)
            {
                comboBox.SelectedIndex = 0;
            }
        }

        // Метод для получения всех доступных ASIO-драйверов
        public static List<string> GetAsioDriverNames()
        {
            List<string> driverList = new List<string>();

            // Получаем список всех доступных ASIO-драйверов
            foreach (var driverName in AsioOut.GetDriverNames())
            {
                driverList.Add(driverName);
            }

            return driverList;
        }
    }
}
