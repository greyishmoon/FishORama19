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
    class OrangeFish : IDraw
    {
        // CLASS VARIABLES
        // Variables hold the information for the class.
        private string textureID;       // Holds a string to identify asset used for this token
        private Vector2 position;       // Holds X and Y coordinates for token position on screen
        private Vector2 direction;      // Holds the direction the fish is currently facing, both X and Y values should be either -1 (left or up) or 1 (right or down)
        private Vector2 size;           // Holds the size of the image associated with this token

        /// <summary>
        /// OrangeFish Constructor
        /// </summary>
        /// <param name="pTextureID">ID of the texture that should be used for this token</param>
        /// <param name="pPosition">Starting coordinates of the token</param>
        /// <param name="pAssetManager">Reference to the AssetManager, used to find the size of the token's visible texture</param>
        public OrangeFish(string pTextureID, Vector2 pPosition, IGetAsset pAssetManager)
        {
            textureID = pTextureID;
            position = pPosition;
            direction = new Vector2(1, 1);
            size = pAssetManager.GetAssetByID(textureID).Size;
        }

        /// <summary>
        /// Update Method
        /// </summary>
        public void Update()
        {
            position.X += direction.X;
        }

        /// <summary>
        /// Draw Method
        /// </summary>
        /// <param name="pAssetManager">Reference to the AssetManager which stores the assets required for drawing</param>
        /// <param name="pSpriteBatch">Reference to an open SpriteBatch, to add this token's texture to</param>
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
