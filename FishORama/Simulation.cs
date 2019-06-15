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
        private Kernel kernel;

        OrangeFish orangeFish1;

        public Simulation(Kernel pKernel)
        {
            kernel = pKernel;
        }
        
        public void LoadContent(AssetManager pAssetManager)
        {
            orangeFish1 = new OrangeFish("OrangeFish", new Vector2(0, 0), pAssetManager);
            kernel.InsertToken(orangeFish1);
        }

        public void Update()
        {
            orangeFish1.Update();
        }
    }
}
