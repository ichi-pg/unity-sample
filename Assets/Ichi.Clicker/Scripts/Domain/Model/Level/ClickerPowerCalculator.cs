using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace Ichi.Clicker
{
    public class ClickerPowerCalculator : ILevelCalculator
    {
        public BigInteger Calculate(int level, int rank, int rarity) {
            return PowerCalculate(level);
        }

        public static BigInteger PowerCalculate(int level) {
            //TODO オート1時間/1フィーバー、20フィーバー/1日、100クリック/フィーバー秒
            //TODO レベルが上がるとランクも上がるイメージ、50:1？
            return BigInteger.Pow(PowerCalculator.LevelCalculate(level), 2) * level;
        }
    }
}
