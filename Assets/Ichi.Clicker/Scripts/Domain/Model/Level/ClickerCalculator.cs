using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace Ichi.Clicker
{
    public class ClickerCalculator : ILevelCalculator
    {
        public BigInteger Calculate(int level, int rank, int rarity) {
            //TODO オート1時間/1フィーバー、20フィーバー/1日、100クリック/フィーバー秒
            return BigInteger.Pow(level, 3);
        }
    }
}
