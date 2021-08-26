using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace Ichi.Clicker
{
    public class FeverCalculator : IStatusCalculator<int>
    {
        public int Calculate(int level, int rank, int rarity) {
            return level / 50 + 1;
        }
    }
}
