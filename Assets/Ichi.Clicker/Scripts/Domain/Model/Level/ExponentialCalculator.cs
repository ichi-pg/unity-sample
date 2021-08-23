using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace Ichi.Clicker
{
    public class ExponentialCalculator : ILevelCalculator
    {
        private int coefficient;

        public ExponentialCalculator(int coefficient) {
            this.coefficient = coefficient;
        }

        public BigInteger Calculate(int level, int rank, int rarity) {
            var x = BigInteger.Pow(this.coefficient, (int)(rank - 1)) + level;
            return x * x;
        }
    }
}
