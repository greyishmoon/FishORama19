using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FishLibrary
{
    public class ChickenLeg : IDraw
    {
        private string textureID;
        private Vector2 position;

        public string TextureID
        {
            get { return textureID; }
        }
        public Vector2 Position
        {
            get { return position; }
        }

        public ChickenLeg(string pTextureID, Vector2 pPosition)
        {
            textureID = pTextureID;
            position = pPosition;
        }

        /// <summary>
        /// Draw Method
        /// </summary>
        /// <param name="pAssetManager">Reference to the AssetManager which stores the assets required for drawing</param>
        /// <param name="pSpriteBatch">Reference to an open SpriteBatch, to add this token's texture to</param>
        public void Draw(AssetManager pAssetManager, SpriteBatch pSpriteBatch)
        {
            Asset currentAsset = pAssetManager.GetAssetByID(textureID); // Get this token's asset from the AssetManager
            
            // Draw an image centered at the token's position, using the associated texture
            pSpriteBatch.Draw(currentAsset.texture,
                              position,
                              null,
                              Color.White,
                              0f,
                              new Vector2(currentAsset.size.X / 2, currentAsset.size.Y / 2),
                              new Vector2(1, 1),
                              SpriteEffects.None,
                              1);
        }
    }
}
