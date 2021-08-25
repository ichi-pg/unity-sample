using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace Ichi.Clicker
{
    public class CostCalculator : ILevelCalculator
    {
        public BigInteger Calculate(int level, int rank, int rarity) {
            //パワーに対してレベル分の指数
            var offsetLevel = PowerCalculator.OffsetLevel(level, rank);
            return PowerCalculator.LevelUpInflation(offsetLevel) * offsetLevel * offsetLevel;
        }
    }
}
