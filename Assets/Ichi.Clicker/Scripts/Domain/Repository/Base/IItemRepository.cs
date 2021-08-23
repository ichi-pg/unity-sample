using System.Collections;
using System.Collections.Generic;

namespace Ichi.Clicker
{
    public interface IItemRepository
    {
        IItem Coin { get; }
        IItem Product { get; }
        void Sell(IItem item);
    }
}
