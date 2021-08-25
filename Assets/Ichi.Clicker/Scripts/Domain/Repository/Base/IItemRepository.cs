using System.Collections;
using System.Collections.Generic;

namespace Ichi.Clicker
{
    public interface IItemRepository
    {
        IQuantity Coin { get; }
        IQuantity Product { get; }
        void Sell(IQuantity item);
    }
}
