using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System;

namespace Ichi.Clicker
{
    public class HPCalculator : ICalculator<BigInteger>
    {
        public BigInteger Calculate(int level = 1, int rank = 1, int rarity = 1) {
            return level * rank * rarity * 20;
        }
    }
}
