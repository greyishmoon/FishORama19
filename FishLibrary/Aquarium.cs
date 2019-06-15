using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FishLibrary
{
    class Aquarium : IDraw
    {
        private string textureID;
        private Vector2 position;
        private Vector2 size;
        
        public Aquarium(string pTextureID, Vector2 pPosition, AssetManager pAssetManager)
        {
            textureID = pTextureID;
            position = pPosition;
            size = pAssetManager.GetAssetByID(textureID).size;
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
                              new Vector2(currentAsset.size.X / 2, currentAsset.size.Y / 2),
                              new Vector2(1, 1),
                              SpriteEffects.None,
                              1);
        }
    }
}
