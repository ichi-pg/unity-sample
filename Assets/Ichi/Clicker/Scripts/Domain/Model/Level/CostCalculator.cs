using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System;

namespace Ichi.Clicker
{
    public class CostCalculator : IStatusCalculator<BigInteger>
    {
        public BigInteger Calculate(int level, int rank, int rarity) {
            //パワーに対してレベル分の指数
            var offsetLevel = PowerCalculator.OffsetLevel(level, rank);
            return LevelUpInflation(offsetLevel) * offsetLevel * offsetLevel;
        }

        private static BigInteger LevelUpInflation(int level) {
            //レベルが25上がるごとに生産量が倍（シームレス）
            return new BigInteger(Math.Pow(2, (double)(level - 1) / 25));
        }
    }
}
