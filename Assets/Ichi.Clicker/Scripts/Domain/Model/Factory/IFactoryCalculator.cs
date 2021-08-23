using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace Ichi.Clicker
{
    public interface IFactoryCalculator
    {
        BigInteger Power(BigInteger level, BigInteger rank, BigInteger rarity);
        BigInteger Cost(BigInteger level, BigInteger rank, BigInteger rarity);
        BigInteger Price(BigInteger level, BigInteger rank, BigInteger rarity);
        long Interval { get; }
    }
}
