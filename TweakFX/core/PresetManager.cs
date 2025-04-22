using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TweakFX.core
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;
    using dfsa.ui.controls;

    public class PresetManager
    {
        private readonly List<DistortionKnob> _knobs;

        public PresetManager(List<DistortionKnob> knobs)
        {
            _knobs = knobs;
        }

        public void SavePreset(string filePath)
        {
            var preset = new XElement("Preset");

            foreach (var knob in _knobs)
            {
                preset.Add(new XElement(knob.Name, knob.Value));
            }

            var doc = new XDocument(preset);
            doc.Save(filePath);
        }

        public void LoadPreset(string filePath)
        {
            if (!File.Exists(filePath))
                return;

            var doc = XDocument.Load(filePath);

            foreach (var element in doc.Root.Elements())
            {
                var knob = _knobs.FirstOrDefault(k => k.Name == element.Name.LocalName);
                if (knob != null && float.TryParse(element.Value, out float value))
                {
                    knob.Value = value;
                }
            }
        }
    }
}
