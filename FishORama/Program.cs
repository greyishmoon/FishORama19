using System;
using FishLibrary;

namespace FishORama
{
#if WINDOWS || LINUX

    /// CLASS: Program
    public static class Program
    {

        /// METHOD: Main - The main entry point for the application - called by the OS when the executable is run
        [STAThread]
        static void Main()
        {
            using (var game = new Kernel())
            {
                Simulation kernel = new Simulation(game);
                game.Simulation = kernel;
                game.Run();
            }
        }
    }
#endif
}
