using System.Collections;
using System.Collections.Generic;

namespace Ichi.Clicker
{
    public interface IItemRepository
    {
        Item Coin { get; }
        Item Product { get; }
        void Collect();
    }
}
