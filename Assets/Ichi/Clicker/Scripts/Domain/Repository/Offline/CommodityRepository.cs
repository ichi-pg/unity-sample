using System.Collections;
using System.Collections.Generic;

namespace Ichi.Clicker.Offline
{
    public class CommodityRepository : ICommodityRepository
    {
        public IItem Commodity { get => SaveData.Instance.Commodity; }

        public void Collect() {
            SaveData.Instance.Commodity.Sell(SaveData.Instance.Coin);
        }
    }
}
