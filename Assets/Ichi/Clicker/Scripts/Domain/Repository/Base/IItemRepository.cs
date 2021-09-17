using System.Collections;
using System.Collections.Generic;

namespace Ichi.Clicker
{
    public interface IItemRepository
    {
        IItem GetItem(ItemCategory category);
    }
}
