using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System;

namespace Ichi.Clicker
{
    public class CostCalculator : ILevelCalculator
    {
        public BigInteger Calculate(int level, int rank, int rarity) {
            //パワーに対してレベル分の指数
            var offsetLevel = PowerCalculator.OffsetLevel(level, rank);
            return PowerCalculator.LevelUpInflation(offsetLevel) * offsetLevel * offsetLevel;
        }

        public static BigInteger RankCap(int level, int rank) {
            //ランクが上がるごとに倍、レベルが50上がるごとに半分
            return Math.Max(1, (int)(Math.Pow(2, rank - 1) / Math.Pow(2, level / 50)));
        }
    }
}
