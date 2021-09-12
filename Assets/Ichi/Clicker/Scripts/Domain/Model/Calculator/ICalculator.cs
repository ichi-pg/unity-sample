using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace Ichi.Clicker
{
    public interface ICalculator<T>
    {
        T Calculate(int level, int rank, int rarity);
    }
}
