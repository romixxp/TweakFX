using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TweakFX.core.effects.delay_reeverb
{
    public class Delay : IAudioEffect
    {
        private float[] _delayBuffer;  // Буфер для хранения задержанных данных
        private int _delayTimeInSamples; // Время задержки в сэмплах
        private int _writeIndex;  // Индекс, куда записываются новые сэмплы
        private float _feedback;  // Обратная связь для эффекта
        private float _wetMix;  // Соотношение Wet/Dry (мокрый/сухой сигнал)
        private float _dryMix;  // Соотношение сухого сигнала

        public Delay(int delayTimeInMs, float feedback = 0.5f, float wetMix = 0.5f, float dryMix = 0.5f, int sampleRate = 44100)
        {
            // Инициализация буфера
            _delayTimeInSamples = (int)(delayTimeInMs * (sampleRate / 1000.0f));  // Преобразование времени задержки в сэмплы
            _delayBuffer = new float[_delayTimeInSamples];
            _writeIndex = 0;
            _feedback = feedback;
            _wetMix = wetMix;
            _dryMix = dryMix;
        }

        // Метод для обновления параметров эффекта
        public void UpdateDelayTime(int delayTimeInMs, int sampleRate = 44100)
        {
            _delayTimeInSamples = (int)(delayTimeInMs * (sampleRate / 1000.0f));
            _delayBuffer = new float[_delayTimeInSamples];
            _writeIndex = 0;  // Сбросить индекс для записи в новый буфер
        }

        public void UpdateFeedback(float feedback)
        {
            _feedback = feedback;
        }

        public void UpdateWetMix(float wetMix)
        {
            _wetMix = wetMix;
        }

        public void UpdateDryMix(float dryMix)
        {
            _dryMix = dryMix;
        }

        public void Process(float[] buffer, int offset, int count)
        {
            for (int i = offset; i < offset + count; i++)
            {
                // Получаем текущий сэмпл
                float currentSample = buffer[i];

                // Получаем задержанный сэмпл из буфера
                float delayedSample = _delayBuffer[_writeIndex];

                // Записываем текущий сэмпл в буфер
                _delayBuffer[_writeIndex] = currentSample + delayedSample * _feedback;

                // Применяем смешивание мокрого и сухого сигнала
                buffer[i] = currentSample * _dryMix + delayedSample * _wetMix;

                // Переход к следующему индексу в буфере
                _writeIndex = (_writeIndex + 1) % _delayTimeInSamples;
            }
        }
    }
}
