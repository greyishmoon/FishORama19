using System;
using FishLibrary;

namespace FishORama
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var game = new Kernel())
            {
                IUpdate kernel = new Simulation(game);
                game.Simulation = kernel;
                game.Run();
            }
                
                
        }
    }
#endif
}
