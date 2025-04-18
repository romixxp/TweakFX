using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TweakFX.core
{
    using System;

    public class DistortionEffect : IAudioEffect
    {
        public float Gain { get; set; }
        public float Tone { get; set; }

        public DistortionEffect(float gain = 5.0f, float tone = 0.5f)
        {
            Gain = gain;
            Tone = tone;
        }

        public byte[] Process(byte[] buffer, int bytesRecorded)
        {
            byte[] output = new byte[bytesRecorded];

            for (int i = 0; i < bytesRecorded; i += 2)
            {
                short sample = (short)(buffer[i] | (buffer[i + 1] << 8));

                float floatSample = sample / 32768.0f;
                floatSample *= Gain;

                // Клиппинг
                floatSample = Math.Max(-1.0f, Math.Min(1.0f, floatSample));

                // Фильтрация "тонами"
                float toneFactor = 0.5f + 0.5f * Tone;
                floatSample *= toneFactor;

                short outSample = (short)(floatSample * 32767.0f);

                output[i] = (byte)(outSample & 0xFF);
                output[i + 1] = (byte)((outSample >> 8) & 0xFF);
            }

            return output;
        }
    }
}
