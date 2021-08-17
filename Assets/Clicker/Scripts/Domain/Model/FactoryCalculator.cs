using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Clicker
{
    public class FactoryCalculator : Factory.ICalculator
    {
        public float Interval { get => 1.0f; }

        public BigInteger Power(int level, int rank) {
            return new BigInteger(level) * rank * (rank + 4);
        }
        public BigInteger Cost(int level, int rank) {
            return new BigInteger(level) * level * rank + 20 * rank * rank * rank;
        }
    }
}
