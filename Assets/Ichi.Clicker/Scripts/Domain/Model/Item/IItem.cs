using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace Ichi.Clicker
{
    public interface IItem : IStore, IConsume
    {
        BigInteger Quantity { get; }
        bool Store(BigInteger quantity);
        bool Consume(BigInteger quantity);
        bool Sell(IStore store);
    }
}
