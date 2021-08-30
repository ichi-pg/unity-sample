using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace Ichi.Clicker
{
    public static class Inflation
    {
        public const int Level = 25;

        public static bool IsInflation(int level) {
            return level % Level == 0;
        }
    }
}
