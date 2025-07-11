using dfsa.ui;
using TweakFX.core;

namespace TweakFX
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        public static AsioInput asioInput;
        public static AsioOutput asioOutput;
        public static AudioEngine engine;
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DistortionNeonPedal());
        }
    }
}