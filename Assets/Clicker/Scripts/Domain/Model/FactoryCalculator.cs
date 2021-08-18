using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Clicker
{
    public class FactoryCalculator : Factory.ICalculator
    {
        public float Interval { get => 1.0f; }


        public BigInteger Power(BigInteger level, BigInteger rank) {
            rank--;
            if (level > 0) {
                level += BigInteger.Pow(5, (int)rank);
            }
            return level;
        }


        public BigInteger Cost(BigInteger level, BigInteger rank) {
            rank--;
            level += 1;
            level += BigInteger.Pow(5, (int)rank);
            return level * level;
        }
    }
}
