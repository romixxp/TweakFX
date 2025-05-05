using System;

namespace TweakFX.core.effects.spatial
{
    public class Spatializer : IAudioEffect
    {
        private float _azimuth;
        private int _sampleRate;

        public Spatializer(float azimuth = 0f, int sampleRate = 44100)
        {
            _azimuth = azimuth;
            _sampleRate = sampleRate;
        }

        public void SetAzimuth(float azimuth)
        {
            _azimuth = Math.Clamp(azimuth, -90f, 90f);
        }

        public void Process(float[] buffer, int offset, int count)
        {
            for (int i = offset; i < offset + count; i += 2)
            {
                float left = buffer[i];
                float right = buffer[i + 1];
                float pan = (_azimuth + 90f) / 180f; 
                float gainL = (float)Math.Cos(pan * Math.PI / 2); // L 
                float gainR = (float)Math.Sin(pan * Math.PI / 2); // R 

                buffer[i] = left * gainL;
                buffer[i + 1] = right * gainR;
            }
        }
    }
}
