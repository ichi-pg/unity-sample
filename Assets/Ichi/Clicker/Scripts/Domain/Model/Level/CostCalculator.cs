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
            //TODO 階段 : シームレスなら指数不要（ゲーム深度でレベルアップ速度は変化しない。ランクアップ速度で深度感は調整する）
            var offsetLevel = OffsetLevel.Calculate(level, rank);
            return new BigInteger(LevelUpInflation(offsetLevel) * offsetLevel) * offsetLevel;
        }

        private static double LevelUpInflation(int level) {
            //レベルが25上がるごとに生産量が倍（シームレス）
            return Math.Pow(2, (double)level / Inflation.Level);
        }
    }
}
