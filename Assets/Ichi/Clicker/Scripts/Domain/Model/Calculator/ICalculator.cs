using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace Ichi.Clicker
{
    public interface ICalculator<T>
    {
        T Calculate(int level = 1, int rank = 1, int rarity = 1);
    }
}
