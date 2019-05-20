using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using FishLibrary;

namespace FishORama
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Simulation : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        List<ISprite> Drawables = new List<ISprite>();

        Kernel kernel;

        AssetManager assetManager;

        ChickenLeg chickenLeg;

        Camera camera;

        public Simulation()
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
            kernel = new Kernel(this);

            assetManager = new AssetManager();

            camera = new Camera(new Vector3(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2, 0));

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            

            /// Load each texture into the AssetManager as an Asset
            Asset asset;

            asset = new Asset(Content.Load<Texture2D>("Background"), 800, 600);
            assetManager.LoadAsset("Background", asset);

            asset = new Asset(Content.Load<Texture2D>("AquariumBackground"), 800, 600);
            assetManager.LoadAsset("AquariumBackground", asset);

            asset = new Asset(Content.Load<Texture2D>("Midground_Rocks"), 800, 600);
            assetManager.LoadAsset("Midground_Rocks", asset);

            asset = new Asset(Content.Load<Texture2D>("ForegroundSand"), 800, 600);
            assetManager.LoadAsset("ForegroundSand", asset);

            asset = new Asset(Content.Load<Texture2D>("Foreground_Rocks"), 800, 600);
            assetManager.LoadAsset("Foreground_Rocks", asset);

            asset = new Asset(Content.Load<Texture2D>("OrangeFish"), 128, 86);
            assetManager.LoadAsset("OrangeFish", asset);

            asset = new Asset(Content.Load<Texture2D>("BlueFish"), 128, 86);
            assetManager.LoadAsset("BlueFish", asset);

            asset = new Asset(Content.Load<Texture2D>("Seahorse"), 74, 128);
            assetManager.LoadAsset("Seahorse", asset);

            asset = new Asset(Content.Load<Texture2D>("Urchin"), 180, 112);
            assetManager.LoadAsset("Urchin", asset);

            asset = new Asset(Content.Load<Texture2D>("Piranha1"), 132, 128);
            assetManager.LoadAsset("Piranha1", asset);

            asset = new Asset(Content.Load<Texture2D>("Piranha2"), 110, 128);
            assetManager.LoadAsset("Piranha2", asset);

            asset = new Asset(Content.Load<Texture2D>("AnglerFish_Lit"), 128, 108);
            assetManager.LoadAsset("AnglerFish_Lit", asset);

            asset = new Asset(Content.Load<Texture2D>("AnglerFish_Unlit"), 128, 108);
            assetManager.LoadAsset("AnglerFish_Unlit", asset);

            asset = new Asset(Content.Load<Texture2D>("Bubble"), 32, 32);
            assetManager.LoadAsset("Bubble", asset);

            asset = new Asset(Content.Load<Texture2D>("ChickenLeg"), 128, 128);
            assetManager.LoadAsset("ChickenLeg", asset);

            asset = new Asset(Content.Load<Texture2D>("DRUM_Red"), 64, 31);
            assetManager.LoadAsset("DRUM_Red", asset);

            asset = new Asset(Content.Load<Texture2D>("DRUM_Blue"), 64, 31);
            assetManager.LoadAsset("DRUM_Blue", asset);

            kernel.LoadContent();
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if(chickenLeg == null && Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                Vector2 mousePosition = Mouse.GetState().Position.ToVector2();

                mousePosition.X -= camera.Transform.Translation.X;
                mousePosition.Y -= camera.Transform.Translation.Y;

                chickenLeg = new ChickenLeg("ChickenLeg", mousePosition);
            }

            kernel.Update();

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

            foreach(ISprite sprite in Drawables)
            {
                sprite.Draw(assetManager, spriteBatch);
            }

            Asset currentAsset;
            
            if(chickenLeg != null)
            {
                currentAsset = assetManager.GetAssetByID(chickenLeg.TextureID);

                spriteBatch.Draw(currentAsset.texture,
                                 chickenLeg.Position,
                                 null,
                                 Color.White,
                                 0f,
                                 new Vector2(currentAsset.width / 2, currentAsset.height / 2),
                                 new Vector2(1, 1),
                                 SpriteEffects.None,
                                 1);
            }

            spriteBatch.End();
            
            base.Draw(gameTime);
        }

        public void InsertSprite(ISprite pSprite)
        {
            Drawables.Add(pSprite);
        }
    }
}
