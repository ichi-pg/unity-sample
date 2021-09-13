using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System;

namespace Ichi.Clicker
{
    public class CostCalculator : ICalculator<BigInteger>
    {
        public BigInteger Calculate(int level = 1, int rank = 1, int rarity = 1) {
            return (level + 1) * (level + 1) * rank * rank;
        }
    }
}
