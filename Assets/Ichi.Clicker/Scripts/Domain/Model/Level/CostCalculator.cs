using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace Ichi.Clicker
{
    public class CostCalculator : ILevelCalculator
    {
        public BigInteger Calculate(int level, int rank, int rarity) {
            if (level <= 0) {
                //コストに対してランク分の指数（上位ランクの開放難易度）
                return BigInteger.Pow(8, rank - 1) * 100;
            }
            return CostCalculate(PowerCalculator.PowerCalculate(level, rank), level);
        }

        public static BigInteger CostCalculate(BigInteger power, int level) {
            //パワーに対してレベル分の指数（インクリメンタルゲームの基本式）
            return power * level * 10;
        }
    }
}
