using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TweakFX.core.effects.distortion
{
    public class Clipper : IAudioEffect
    {
        private float _distortionAmount; // Уровень дисторшн
        private float _tone; // Тон, контролирует высокие частоты
        private float _volume; // Уровень громкости

        // Конструктор с параметрами
        public Clipper(float distortionAmount = 1.0f, float tone = 0.5f, float volume = 1.0f)
        {
            _distortionAmount = distortionAmount;
            _tone = tone;
            _volume = volume;
        }

        // Метод для обновления дисторшн
        public void UpdateDistortionAmount(float newDistortionAmount)
        {
            _distortionAmount = newDistortionAmount;
        }

        // Метод для обновления тона
        public void UpdateTone(float newTone)
        {
            _tone = newTone;
        }

        // Метод для обновления громкости
        public void UpdateVolume(float newVolume)
        {
            _volume = newVolume;
        }

        public void Process(float[] buffer, int offset, int count)
        {
            for (int i = offset; i < offset + count; i++)
            {
                // Применяем искажение
                buffer[i] *= _distortionAmount;

                // Применяем эквалайзер (Tone)
                buffer[i] = ApplyTone(buffer[i]);

                // Применяем громкость
                buffer[i] *= _volume;
            }
        }

        private float ApplyTone(float sample)
        {
            // Плавная интерполяция между усилением низких и высоких частот
            // При значении _tone = 0, акцент на низкие частоты
            // При значении _tone = 1, акцент на высокие частоты

            if (_tone < 0.5f)
            {
                // Больше низких частот (для значений ниже 0.5)
                return sample * (1.0f - (0.5f - _tone) * 2.0f); // Увеличиваем низкие частоты
            }
            else
            {
                // Больше высоких частот (для значений выше 0.5)
                return sample * (1.0f + (_tone - 0.5f) * 2.0f); // Увеличиваем высокие частоты
            }
        }
    }
}
