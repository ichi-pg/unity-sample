using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace Ichi.Clicker
{
    public interface IItem : IStore, IConsume
    {
        BigInteger Quantity { get; }
        bool Sell(IStore store);

        //TODO UIにプロパティだけ公開する
    }
}
