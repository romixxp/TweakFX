using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TweakFX.core
{
    public static class OLD_AudioEngine
    {
        private static AudioConfig _config;
        private static AsioInput _asioInput;
        private static AsioOutput _asioOutput;
        private static WasapiOutput _wasapiOutput;
        private static EffectChain _effectChain;
        private static DistortionEffect _distortion;

        public static void Start(AudioConfig config)
        {
            _config = config;

            _asioInput = new AsioInput(_config);
            _asioOutput = new AsioOutput(_config);
            _wasapiOutput = new WasapiOutput();

            _distortion = new DistortionEffect(8.0f, 0.6f);

            _effectChain = new EffectChain();
            _effectChain.AddEffect(_distortion);

            _asioInput.OnAudioAvailable += OnAudioAvailable;
            _asioInput.Start();
        }

        private static void OnAudioAvailable(object sender, AudioAvailableEventArgs e)
        {
            var processed = _effectChain.Process(e.Buffer, e.BytesRecorded);

            _asioOutput.Send(processed, e.BytesRecorded);
            _wasapiOutput.Send(processed, e.BytesRecorded);
        }

        public static void ChangeConfig(AudioConfig newConfig)
        {
            _asioInput.Stop();
            _asioOutput.Stop();

            _config = newConfig;

            _asioInput = new AsioInput(_config);
            _asioOutput = new AsioOutput(_config);

            _asioInput.OnAudioAvailable += OnAudioAvailable;
            _asioInput.Start();
        }

        public static void SetDistortionGain(float gain) => _distortion.Gain = gain;
        public static void SetDistortionTone(float tone) => _distortion.Tone = tone;
    }

}
