using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace Ichi.Clicker
{
    public class LinearCalculator : ILevelCalculator
    {
        private int coefficient;

        public LinearCalculator(int coefficient) {
            this.coefficient = coefficient;
        }

        public BigInteger Calculate(int level, int rank, int rarity) {
            var x = BigInteger.Pow(this.coefficient, rank - 1) + level;
            return x * rank;
        }
    }
}
