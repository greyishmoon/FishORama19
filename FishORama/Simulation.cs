using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using FishLibrary;

namespace FishORama
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Simulation : IUpdate, ILoadContent
    {
        // CLASS VARIABLES
        // Variables hold the information for the class.
        private IKernel kernel;     // Holds a reference to the kernel which calls the draw method for every token you add to it

        OrangeFish orangeFish1;

        /// <summary>
        /// Simulation Constructor
        /// </summary>
        /// <param name="pKernel">The game's Kernel</param>
        public Simulation(IKernel pKernel)
        {
            kernel = pKernel; // Stores the kernel passed to the constructor when this class is created
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        /// <param name="pAssetManager">Asset manager containing the assets used by each token</param>
        public void LoadContent(IGetAsset pAssetManager)
        {
            orangeFish1 = new OrangeFish("OrangeFish", new Vector2(0, 0), pAssetManager);
            kernel.InsertToken(orangeFish1);
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public void Update(GameTime gameTime)
        {
            orangeFish1.Update();
        }
    }
}
