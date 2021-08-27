using System.Collections;
using System.Collections.Generic;

namespace Ichi.Clicker.Offline
{
    public class ProductRepository : IProductRepository
    {
        public IItem Product { get => SaveData.Instance.Product; }

        public void Collect() {
            SaveData.Instance.Product.Sell(SaveData.Instance.Coin);
        }
    }
}
