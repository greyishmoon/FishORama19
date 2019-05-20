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
    class Aquarium : ISprite
    {
        private string textureID;

        private Vector2 position;
        
        public Aquarium(string pTextureID, Vector2 pPosition)
        {
            textureID = pTextureID;

            position = pPosition;
        }

        public void Update()
        {
        }

        public void Draw(AssetManager pAssetManager, SpriteBatch pSpriteBatch)
        {
            Asset currentAsset = pAssetManager.GetAssetByID(textureID);
            
            pSpriteBatch.Draw(currentAsset.texture,
                              position,
                              null,
                              Color.White,
                              0f,
                              new Vector2(currentAsset.width / 2, currentAsset.height / 2),
                              new Vector2(1, 1),
                              SpriteEffects.None,
                              1);
        }
    }
}
