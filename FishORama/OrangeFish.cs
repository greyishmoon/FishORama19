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
        private string textureID;
        
        private Vector2 position;

        private Vector2 direction = new Vector2(1, 1);

        public OrangeFish(string pTextureID, Vector2 pPosition)
        {
            textureID = pTextureID;
            position = pPosition;
        }

        public void Update()
        {
            position.X += 1;
        }

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
                              new Vector2(currentAsset.width / 2, currentAsset.height / 2),
                              new Vector2(1, 1),
                              horizontalDirection,
                              1);
        }
    }
}
