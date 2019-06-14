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
    class OrangeFish : ISprite
    {
        // CLASS VARIABLES
        // Variables hold the information for the class.
        private string textureID;       // Holds a string to identify asset used for this token
        private Vector2 position;       // Holds X and Y coordinates for token position on screen
        private Vector2 direction;  
        private Vector2 size;

        // CONSTRUCTOR
        public OrangeFish(string pTextureID, Vector2 pPosition, AssetManager pAssetManager)
        {
            textureID = pTextureID;
            position = pPosition;
            direction = new Vector2(1, 1);
            size = pAssetManager.GetAssetByID(textureID).size;
        }

        // UPDATE METHOD
        public void Update()
        {
            position.X += 1;
        }

        //DRAW METHOD
        public void Draw(AssetManager pAssetManager, SpriteBatch pSpriteBatch)
        {
            Asset currentAsset = pAssetManager.GetAssetByID(textureID);

            SpriteEffects horizontalDirection;

            if(direction.X < 0)
            {
                horizontalDirection = SpriteEffects.FlipHorizontally;
            }
            else
            {
                horizontalDirection = SpriteEffects.None;
            }

            pSpriteBatch.Draw(currentAsset.texture,
                              position,
                              null,
                              Color.White,
                              0f,
                              new Vector2(currentAsset.size.X / 2, currentAsset.size.Y / 2),
                              new Vector2(1, 1),
                              horizontalDirection,
                              1);
        }
    }
}
