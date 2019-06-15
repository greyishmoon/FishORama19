using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FishLibrary
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Kernel : Game
    {
        // CLASS VARIABLES
        // Variables hold the information for the class.
        private GraphicsDeviceManager graphics;     // Used to control the graphics device which draws each frame
        private SpriteBatch spriteBatch;            // Part of the drawing process, used to batch textures together to improve render speed
        private List<IDraw> drawables;             // List of each token to be drawn each frame
        private IUpdate simulation;              // Holds a reference to the game simulation to be able to call its Update method each frame
        private AssetManager assetManager;          // Stores every texture that can be used by tokens
        private ChickenLeg chickenLeg;              // Stores a reference to the chicken leg while it's on the screen
        private Camera camera;                      // Every token is drawn in a position relative to this camera
        
        // CLASS PROPERTIES
        // Properties expose private variables as public to other classes
        public IUpdate Simulation
        {
            set { simulation = value; }
        }

        public ChickenLeg ChickenLeg
        {
            get { return chickenLeg; }
        }

        public Kernel()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;

            Content.RootDirectory = "Content";

            IsMouseVisible = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            assetManager = new AssetManager();
            camera = new Camera(new Vector3(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2, 0)); // Create a new camera for centering tokens to the viewpoint
            drawables = new List<IDraw>();

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            Console.WriteLine("Welcome to the FishORama Framework");

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            

            // Load each texture into the AssetManager as an Asset
            Asset asset;

            asset = new Asset(Content.Load<Texture2D>("Background"), new Vector2(800, 600));
            assetManager.LoadAsset("Background", asset);

            asset = new Asset(Content.Load<Texture2D>("AquariumBackground"), new Vector2(800, 600));
            assetManager.LoadAsset("AquariumBackground", asset);

            asset = new Asset(Content.Load<Texture2D>("Midground_Rocks"), new Vector2(800, 600));
            assetManager.LoadAsset("Midground_Rocks", asset);

            asset = new Asset(Content.Load<Texture2D>("ForegroundSand"), new Vector2(800, 600));
            assetManager.LoadAsset("ForegroundSand", asset);

            asset = new Asset(Content.Load<Texture2D>("Foreground_Rocks"), new Vector2(800, 600));
            assetManager.LoadAsset("Foreground_Rocks", asset);

            asset = new Asset(Content.Load<Texture2D>("OrangeFish"), new Vector2(128, 86));
            assetManager.LoadAsset("OrangeFish", asset);

            asset = new Asset(Content.Load<Texture2D>("BlueFish"), new Vector2(128, 86));
            assetManager.LoadAsset("BlueFish", asset);

            asset = new Asset(Content.Load<Texture2D>("Seahorse"), new Vector2(74, 128));
            assetManager.LoadAsset("Seahorse", asset);

            asset = new Asset(Content.Load<Texture2D>("Urchin"), new Vector2(180, 112));
            assetManager.LoadAsset("Urchin", asset);

            asset = new Asset(Content.Load<Texture2D>("Piranha1"), new Vector2(132, 128));
            assetManager.LoadAsset("Piranha1", asset);

            asset = new Asset(Content.Load<Texture2D>("Piranha2"), new Vector2(110, 128));
            assetManager.LoadAsset("Piranha2", asset);

            asset = new Asset(Content.Load<Texture2D>("AnglerFish_Lit"), new Vector2(128, 108));
            assetManager.LoadAsset("AnglerFish_Lit", asset);

            asset = new Asset(Content.Load<Texture2D>("AnglerFish_Unlit"), new Vector2(128, 108));
            assetManager.LoadAsset("AnglerFish_Unlit", asset);

            asset = new Asset(Content.Load<Texture2D>("Bubble"), new Vector2(32, 32));
            assetManager.LoadAsset("Bubble", asset);

            asset = new Asset(Content.Load<Texture2D>("ChickenLeg"), new Vector2(128, 128));
            assetManager.LoadAsset("ChickenLeg", asset);

            asset = new Asset(Content.Load<Texture2D>("DRUM_Red"), new Vector2(64, 31));
            assetManager.LoadAsset("DRUM_Red", asset);

            asset = new Asset(Content.Load<Texture2D>("DRUM_Blue"), new Vector2(64, 31));
            assetManager.LoadAsset("DRUM_Blue", asset);

            // Create a new Aquarium to act as the background for the game
            Aquarium aquarium = new Aquarium("AquariumBackground", new Vector2(0, 0), assetManager);
            InsertToken(aquarium);

            (simulation as ILoadContent).LoadContent(assetManager); // Call the kernel's LoadContent method, for it to create tokens and add them to the game
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if(chickenLeg == null && Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                Vector2 mousePosition = Mouse.GetState().Position.ToVector2();

                mousePosition.X -= camera.Transform.Translation.X;
                mousePosition.Y -= camera.Transform.Translation.Y;

                chickenLeg = new ChickenLeg("ChickenLeg", mousePosition);
                InsertToken(chickenLeg);
            }

            simulation.Update();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin(SpriteSortMode.FrontToBack, 
                              null, 
                              null, 
                              null, 
                              null, 
                              null, 
                              camera.Transform);

            foreach(IDraw Token in drawables)
            {
                Token.Draw(assetManager, spriteBatch);
            }

            spriteBatch.End();
            
            base.Draw(gameTime);
        }

        public void InsertToken(IDraw pToken)
        {
            drawables.Add(pToken);
        }

        public void RemoveToken(IDraw pToken)
        {
            drawables.Remove(pToken);
        }

        public void RemoveChickenLeg()
        {
            if(chickenLeg != null)
            {
                RemoveToken(chickenLeg);
                chickenLeg = null;
            }
        }
    }
}
