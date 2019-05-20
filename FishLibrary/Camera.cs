using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace FishLibrary
{
    public class Camera
    {
        private Matrix transform;
        public Matrix Transform
        {
            get { return transform; }
        }

        public Camera(Vector3 pCameraPosition)
        {
            transform = Matrix.CreateTranslation(pCameraPosition);
        }
    }
}
