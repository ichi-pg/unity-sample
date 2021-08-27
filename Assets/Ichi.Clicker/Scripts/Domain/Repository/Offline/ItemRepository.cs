using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Ichi.Clicker.Offline
{
    public class ItemRepository : IItemRepository
    {
        public IQuantity Coin { get => SaveData.Instance.Coin; }
        public IQuantity Product { get => SaveData.Instance.Product; }

        public void Sell(IQuantity item) {
            (item as Item).Sell(this.Coin as Item);
        }
    }
}
