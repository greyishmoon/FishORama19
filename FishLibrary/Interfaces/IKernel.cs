using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishLibrary
{
    public interface IKernel
    {
        IToken ChickenLeg { get; }
        Viewport Screen { get; }

        void InsertToken(IDraw pToken);
        void RemoveToken(IDraw pToken);
        void RemoveChickenLeg();
    }
}
