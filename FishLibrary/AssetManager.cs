using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishLibrary
{
    public class AssetManager
    {
        private Dictionary<string, Asset> assets = new Dictionary<string, Asset>();

        public void LoadAsset(string pKey, Asset pAsset)
        {
            assets.Add(pKey, pAsset);
        }

        public Asset GetAssetByID(string pKey)
        {
            return assets[pKey];
        }
    }
}
