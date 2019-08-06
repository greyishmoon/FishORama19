using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FishLibrary
{
    public class ChickenLeg : IDraw, IToken
    {
        private string textureID;       // Holds a string to identify asset used for this token
        private Vector2 position;       // Holds X and Y coordinates for token position on screen
        private bool removeFlag;            // Flag  - remove chickenLeg of true (polled by kernel update)

        public string TextureID
        {
            get { return textureID; }
        }
        public Vector2 Position
        {
            get { return position; }
        }

        public bool RemoveFlag
        {
            get { return removeFlag; }
        }

        public ChickenLeg(string pTextureID, Vector2 pPosition)
        {
            textureID = pTextureID;
            position = pPosition;
            removeFlag = false;
        }

        public void Remove()
        {
            removeFlag = true;
        }

        /// <summary>
        /// Draw Method
        /// </summary>
        /// <param name="pAssetManager">Reference to the AssetManager which stores the assets required for drawing</param>
        /// <param name="pSpriteBatch">Reference to an open SpriteBatch, to add this token's texture to</param>
        public void Draw(IGetAsset pAssetManager, SpriteBatch pSpriteBatch)
        {
            Asset currentAsset = pAssetManager.GetAssetByID(textureID); // Get this token's asset from the AssetManager
            
            // Draw an image centered at the token's position, using the associated texture
            pSpriteBatch.Draw(currentAsset.Texture,
                              position,
                              null,
                              Color.White,
                              0f,
                              new Vector2(currentAsset.Size.X / 2, currentAsset.Size.Y / 2),
                              new Vector2(1, 1),
                              SpriteEffects.None,
                              1);
        }
    }
}
