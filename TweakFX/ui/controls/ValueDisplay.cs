using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dfsa.ui.controls
{
    public class ValueDisplay : TextBox
    {
        public ValueDisplay()
        {
            ReadOnly = true;
            BackColor = Color.FromArgb(30, 200, 200);
            ForeColor = Color.Black;
            TextAlign = HorizontalAlignment.Center;
            Font = new Font("Arial", 10, FontStyle.Bold);
        }

        public void UpdateValue(float value)
        {
            Text = (value * -60).ToString("0.0") + " dB";
        }
    }
}
