using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace Ichi.Clicker
{
    public class PowerCalculator : ICalculator<BigInteger>
    {
        public BigInteger Calculate(int level = 1, int rank = 1, int rarity = 1) {
            return level * rank * rarity;
        }
    }
}
