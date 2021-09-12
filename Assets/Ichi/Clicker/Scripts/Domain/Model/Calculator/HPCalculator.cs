using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System;

namespace Ichi.Clicker
{
    public class HPCalculator : ICalculator<BigInteger>
    {
        public BigInteger Calculate(int level, int rank, int rarity) {
            //TODO 調整
            return 100;
        }
    }
}
