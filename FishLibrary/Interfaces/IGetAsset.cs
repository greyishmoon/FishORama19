using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishLibrary
{
    public interface IGetAsset
    {
        Asset GetAssetByID(string pKey);
    }
}
