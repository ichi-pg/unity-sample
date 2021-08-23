using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Ichi.Clicker
{
    public class ItemRepository : IItemRepository
    {
        public IItem Coin { get => SaveData.Instance.Coin; }
        public IItem Product { get => SaveData.Instance.Product; }

        public void Sell(IItem item) {
            item.Sell(this.Coin);
        }
    }
}
