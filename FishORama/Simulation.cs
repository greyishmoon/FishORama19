using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using FishLibrary;

namespace FishORama
{
    /// CLASS: Simulation class - the main class users code in to set up a FishORama simulation
    /// All tokens to be displayed in the scene are added here
    public class Simulation : IUpdate, ILoadContent
    {
        // CLASS VARIABLES
        // Variables store the information for the class
        private IKernel kernel;         // Holds a reference to the game engine kernel which calls the draw method for every token you add to it
        private Screen screen;          // Holds a reference to the screeen dimensions (width, height)
        private IToken chickenLeg;      // Holds a reference to the chicken leg variable
        private int testNum;
        bool firstRun = true;

        // *** ADD YOUR CLASS VARIABLES HERE ***

        // EXAMPLE: DECLARATION of an OrangeFish variable that will hold an OrangeFish object
        OrangeFish orangeFish1;

     

        /// CONSTRUCTOR - for the Simulation class - run once only when an object of the Simulation class is INSTANTIATED (created)
        /// Use constructors to set up the state of a class
        public Simulation(IKernel pKernel)
        {
            kernel = pKernel;       // Stores the game engine kernel which is passed to the constructor when this class is created
            screen = kernel.Screen;
            
            
        }

        /// METHOD: LoadContent - called once at start of program
        /// Create all token objects and 'insert' them into the FishORama engine
        public void LoadContent(IGetAsset pAssetManager)
        {
            // *** ADD YOUR NEW TOKEN CREATION CODE HERE ***

            // EXAMPLE: CREATION of a new OrangeFish object, INITIALISATION of the orangeFish1 variable
            // and insertion of the OrangeFish object into the FishORama engine
            orangeFish1 = new OrangeFish("OrangeFish", 0, 0, screen, chickenLeg);
            kernel.InsertToken(orangeFish1);



            //chickenLeg = kernel.ChickenLeg;
        }

        /// METHOD: Update - called 60 times a second by the FishORama engine when the program is running
        /// Add all tokens so Update is called on them regularly
        public void Update(GameTime gameTime)
        {
            if (firstRun)
            {
                chickenLeg = kernel.ChickenLeg;
            }

            // *** ADD YOUR UPDATE CODE HERE ***

            // EXAMPLE: Calling Update() on the example OrangeFish object
            orangeFish1.Update();

            //Console.WriteLine(kernel.ChickenLeg);
            //Console.WriteLine(chickenLeg);

            //if (kernel.ChickenLeg != null)
            //{
            //    Console.WriteLine("SFSG");
            //}


        }
    }
}
