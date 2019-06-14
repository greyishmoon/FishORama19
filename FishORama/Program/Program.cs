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
            using (var game = new Simulation())
            {
                IUpdatable kernel = new Kernel(game);
                game.Kernel = kernel;
                game.Run();
            }
                
                
        }
    }
#endif
}
