using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Ichi.Clicker
{
    public class ItemRepository : IItemRepository
    {
        public Item Get() {
            return SaveData.Instance.Items.First();//TODO
        }
    }
}
