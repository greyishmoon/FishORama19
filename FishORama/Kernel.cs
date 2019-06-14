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
    public class Kernel : IUpdatable, ILoadContent
    {
        private Simulation simulation;

        OrangeFish orangeFish1;

        public Kernel(Simulation pSimulation)
        {
            simulation = pSimulation;
        }
        
        public void LoadContent(AssetManager pAssetManager)
        {
            Aquarium aquarium = new Aquarium("AquariumBackground", new Vector2(0, 0), pAssetManager);
            simulation.InsertSprite(aquarium);

            orangeFish1 = new OrangeFish("OrangeFish", new Vector2(0, 0), pAssetManager);
            simulation.InsertSprite(orangeFish1);
        }

        public void Update()
        {
            orangeFish1.Update();
        }
    }
}
