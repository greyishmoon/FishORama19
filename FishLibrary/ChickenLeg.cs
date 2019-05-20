using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace FishLibrary
{
    public class ChickenLeg
    {
        private string textureID;
        public string TextureID
        {
            get { return textureID; }
        }

        private Vector2 position;
        public Vector2 Position
        {
            get { return position; }
        }

        public ChickenLeg(string pTextureID, Vector2 pPosition)
        {
            textureID = pTextureID;
            position = pPosition;
        }
    }
}
