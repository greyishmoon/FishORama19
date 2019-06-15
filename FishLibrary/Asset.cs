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
        private Texture2D texture;      // Stores the image with which to draw this asset
        private Vector2 size;           // The size of the image, in pixels

        public Texture2D Texture
        {
            get { return texture; }
            set { texture = value; }
        }
        public Vector2 Size
        {
            get { return size; }
            set { size = value; }
        }

        /// <summary>
        /// Asset Constructor
        /// </summary>
        /// <param name="pTexture">Asset's image</param>
        /// <param name="pSize">Size of the given image</param>
        public Asset(Texture2D pTexture, Vector2 pSize)
        {
            texture = pTexture;
            size = pSize;
        }
    }
}
