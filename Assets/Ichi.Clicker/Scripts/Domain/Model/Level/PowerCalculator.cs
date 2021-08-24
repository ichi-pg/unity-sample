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
            return PowerCalculate(level, rank);
        }

        public static BigInteger PowerCalculate(int level, int rank) {
            return RankCalculate(rank) * LevelCalculate(level);
        }

        public static BigInteger RankCalculate(int rank) {
            //ランクが上がるごとに総生産量が倍（ランク開放のカタルシス。上位ランクのシナリオ開放難易度）
            return BigInteger.Pow(2, rank - 1);
        }

        public static BigInteger LevelCalculate(int level) {
            //レベルが25上がるごとに生産量が倍＋変化量0にならないようレベル倍（インフレ具合）
            return BigInteger.Pow(2, (level - 1) / 25) * level;
        }
    }
}
