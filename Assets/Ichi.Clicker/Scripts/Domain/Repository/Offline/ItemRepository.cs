using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Ichi.Clicker
{
    public class ItemRepository : IItemRepository
    {
        public Item Get(Item.Categories category) {
            return SaveData.Instance.Items.FirstOrDefault(t => t.Category == (int)category);
        }
    }
}
