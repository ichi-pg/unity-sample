using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace Ichi.Clicker
{
    public class AutoFactory : IFactoryCalculator
    {
        public BigInteger Power(BigInteger level, BigInteger rank, BigInteger rarity) {
            if (level <= 0) {
                return 0;
            }
            level += BigInteger.Pow(5, (int)(rank - 1));
            return level * rank;
        }

        public BigInteger Cost(BigInteger level, BigInteger rank, BigInteger rarity) {
            level += BigInteger.Pow(5, (int)(rank - 1));
            return level * level;
        }

        public BigInteger Price(BigInteger level, BigInteger rank, BigInteger rarity) {
            throw new System.NotImplementedException();
        }

        public long Interval => 1000;
    }
}
