using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FishLibrary
{
    public class Asset
    {
        public Texture2D texture;

        public Vector2 size;

        public Asset(Texture2D pTexture, Vector2 pSize)
        {
            texture = pTexture;

            size = pSize;
        }
    }
}
