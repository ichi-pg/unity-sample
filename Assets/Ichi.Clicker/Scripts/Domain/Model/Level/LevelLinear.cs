using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace Ichi.Clicker
{
    public class LevelLinear : ILevelCalculator
    {
        //TODO 係数

        public BigInteger Calculate(BigInteger level, BigInteger rank, BigInteger rarity) {
            if (level <= 0) {
                return 0;
            }
            level += BigInteger.Pow(5, (int)(rank - 1));
            return level * rank;
        }
    }
}
