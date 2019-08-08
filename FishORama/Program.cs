using System;
using FishLibrary;

namespace FishORama
{
#if WINDOWS || LINUX

    /// CLASS: Program - the executable class for the project
    public static class Program
    {

        /// METHOD: Main - The main entry point for the application - called by the OS when the executable is run
        /// NOTE - There should be no need to alter this class
        [STAThread]
        static void Main()
        {
            // Create Kernel object (using statement used as Game implements IDisposable)
            using (var kernel = new Kernel())
            {
                // Create Simulation object
                Simulation sim = new Simulation(kernel);
                // Inject Simulation into Kernel
                kernel.Simulation = sim;
                

                // Create TokenManager object
                TokenManager tokenMan = new TokenManager();
                // Inject TokenManager into Kernel
                kernel.TokenManager = tokenMan;
                // Inject TokenManager into Simulation
                sim.TokenManager = tokenMan;

                // Instruct game engine to run simulation
                kernel.Run();
            }
        }
    }
#endif
}
