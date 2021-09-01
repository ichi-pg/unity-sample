using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System;

namespace Ichi.Clicker
{
    public class CostCalculator : IStatusCalculator<BigInteger>
    {
        public BigInteger Calculate(int level, int rank, int rarity) {
            var offsetLevel = StatusUtility.OffsetLevel(level, rank);
            var inflation = LevelUpInflation(offsetLevel);
            //小数点以下を切り捨てられないので別計算
            if (inflation < 1000) {
                return new BigInteger(inflation * offsetLevel) * offsetLevel;
            }
            //パワーに対してレベル分の指数
            return new BigInteger(inflation) * offsetLevel * offsetLevel;
        }

        private static double LevelUpInflation(int level) {
            //レベルが25上がるごとに生産量が倍（シームレス）
            return Math.Pow(2, (double)level / StatusUtility.InflationLevel);
        }
    }
}
