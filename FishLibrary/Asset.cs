using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace FishLibrary
{
    public class Asset
    {
        public Texture2D texture;

        public float width;
        public float height;

        public Asset(Texture2D pTexture, float pWidth, float pHeight)
        {
            texture = pTexture;

            width = pWidth;
            height = pHeight;
        }
    }
}
