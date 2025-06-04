# TweakFX

🎛️ **TweakFX** is a real-time microphone FX processor for Windows, developed in C# (.NET 7.0) by **Leaf Software**.  
It applies studio-grade audio effects to your ASIO microphone input and sends the processed signal to both ASIO outputs (for direct monitoring) and VB Audio Cable (for use with third-party apps like OBS or Discord).

> ⚠️ **Status**: TweakFX is currently under active development. Expect more effects and enhancements soon.

---

## ✨ Features

- 🎚️ **Modern interface** with potentiometers inspired by *dearVR Pro 2*, completely redrawn
- 🎧 **Real-time ASIO monitoring** with virtually no latency
- 🔄 **Dual output routing**:
  - ASIO out (for direct headphone monitoring)
  - VB Audio Cable (for app routing, may introduce OS-level latency)
- 🛠 **Currently implemented effects**:
  - Delay
  - Reverb
  - Pitch Shifter
  - Distortion
- 📈 Built-in **Oscilloscope** (stable at 192-sample buffer)
- 🧪 **Tested hardware**: Focusrite Scarlett 2i2 3rd Gen
- ✅ **Supported sample rates**:
  - 44,100 Hz
  - 48,000 Hz
  - 92,000 Hz
  - 196,000 Hz
  - 384,000 Hz

---

## 🧪 Example Usage

- Speak into a microphone connected through an ASIO interface.
- TweakFX processes your voice in real time.
- You hear yourself through ASIO output with minimal latency.
- Simultaneously, the processed audio is routed to VB Audio Cable for use in software like OBS, Discord, or streaming platforms.

---

## ⚙️ Tech Stack

- **Language**: C#
- **Framework**: .NET 7.0
- **Audio Engine**: NAudio (ASIO backend)
- **UI**: Windows Forms with Drawing.2D rendering

---

## 📜 License

TweakFX is distributed under the [Extended MIT License](./LICENSE).  
You are free to use, modify, and redistribute this software, provided that proper attribution to **TweakFX** and **Leaf Software** is included in any public or derivative version.
