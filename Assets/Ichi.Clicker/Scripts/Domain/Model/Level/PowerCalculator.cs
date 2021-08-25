using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace Ichi.Clicker
{
    public class PowerCalculator : ILevelCalculator
    {
        public BigInteger Calculate(int level, int rank, int rarity) {
            if (level <= 0) {
                return 0;
            }
            var offsetLevel = OffsetLevel(level, rank);
            return LevelUpInflation(offsetLevel) * offsetLevel * 5;
        }

        public static BigInteger LevelUpInflation(int level) {
            //レベルが25上がるごとに生産量が倍
            return BigInteger.Pow(2, (level - 1) / 25);
        }

        public static int OffsetLevel(int level, int rank) {
            //ランクが上がるごとに50レベルずつオフセット
            return level + (rank - 1) * 50;
        }
    }
}
