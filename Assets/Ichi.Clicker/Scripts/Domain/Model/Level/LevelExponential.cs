using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace Ichi.Clicker
{
    public class LevelExponential : ILevelCalculator
    {
        //TODO 係数

        public BigInteger Calculate(BigInteger level, BigInteger rank, BigInteger rarity) {
            level += BigInteger.Pow(5, (int)(rank - 1));
            return level * level;
        }
    }
}
