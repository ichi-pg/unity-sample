using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace Ichi.Clicker
{
    public class PowerCalculator : IStatusCalculator<BigInteger>
    {
        public BigInteger Calculate(int level, int rank, int rarity) {
            if (level <= 0) {
                return 0;
            }
            //定数倍でレベルアップ速度を調整
            var offsetLevel = OffsetLevel.Calculate(level, rank);
            return LevelUpInflation(offsetLevel) * offsetLevel * 5;
        }

        private static BigInteger LevelUpInflation(int level) {
            //レベルが25上がるごとに生産量が倍（階段）
            return BigInteger.Pow(2, level / 25);
        }
    }
}
