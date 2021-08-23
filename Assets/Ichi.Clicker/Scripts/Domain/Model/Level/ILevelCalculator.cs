using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace Ichi.Clicker
{
    public interface ILevelCalculator
    {
        BigInteger Calculate(int level, int rank, int rarity);
    }
}
