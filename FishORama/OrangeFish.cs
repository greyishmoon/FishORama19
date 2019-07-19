using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using FishLibrary;

namespace FishORama
{
    /// CLASS: OrangeFish - this class is structured as a FishORama engine Token class
    /// It contains all the elements required to draw a token to screen and update it (for movement etc)
    class OrangeFish : IDraw
    {
        // CLASS VARIABLES
        // Variables hold the information for the class
        // NOTE - these variables must be present for the class to act as a TOKEN for the FishORama engine
        private string textureID;       // Holds a string to identify asset used for this token
        private Vector2 position;       // Holds X and Y coordinates for token position on screen
        private Vector2 direction;      // Holds the direction the fish is currently facing, both X and Y values should be either -1 (left or up) or 1 (right or down)
        private Vector2 size;           // Holds the size of the image associated with this token (x and y values)

        /// CONSTRUCTOR: OrangeFish Constructor
        /// The elements in the brackets are PARAMETERS, which will be covered later in the course
        public OrangeFish(string pTextureID, Vector2 pPosition, IGetAsset pAssetManager)
        {
            // State initialisation (setup) for the object
            textureID = pTextureID;
            position = pPosition;
            direction = new Vector2(1, 1);
            size = pAssetManager.GetAssetByID(textureID).Size;

            // *** ADD OTHER INITIALISATION (class setup) CODE HERE ***


            
        }

        /// METHOD: Update - Called repeatedly by the Update loop in Simulation
        /// Write the movement control code here
        public void Update()
        {
            position.X += direction.X;

            // *** ADD YOUR MOVEMENT/BEHAVIOUR CODE HERE ***



        }

        /// METHOD: Draw - Called repeatedly by FishORama engine to draw token on screen
        /// DO NOT ALTER, and ensure this Draw method is in each token (fish) class
        /// Comments explain the code - read and try and understand each lines purpose
        public void Draw(IGetAsset pAssetManager, SpriteBatch pSpriteBatch)
        {
            Asset currentAsset = pAssetManager.GetAssetByID(textureID); // Get this token's asset from the AssetManager

            SpriteEffects horizontalDirection; // Stores whether the texture should be flipped horizontally

            if(direction.X < 0)
            {
                // If the token's horizontal direction is negative, draw it inverted
                horizontalDirection = SpriteEffects.FlipHorizontally;
            }
            else
            {
                // If the token's horizontal direction is positive, draw it regularly
                horizontalDirection = SpriteEffects.None;
            }

            // Draw an image centered at the token's position, using the associated texture
            pSpriteBatch.Draw(currentAsset.Texture,
                              position,
                              null,
                              Color.White,
                              0f,
                              new Vector2(currentAsset.Size.X / 2, currentAsset.Size.Y / 2),
                              new Vector2(1, 1),
                              horizontalDirection,
                              1);
        }
    }
}
