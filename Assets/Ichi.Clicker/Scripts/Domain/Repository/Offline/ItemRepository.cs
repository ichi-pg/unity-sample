using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Ichi.Clicker
{
    public class ItemRepository : IItemRepository
    {
        public Item Coin { get => SaveData.Instance.Coin; }
        public Item Product { get => SaveData.Instance.Product; }
    }
}
