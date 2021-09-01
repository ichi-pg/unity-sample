using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace Ichi.Clicker
{
    public static class StatusUtility
    {
        public const int InflationLevel = 25;

        public static bool IsInflation(int level) {
            return level % InflationLevel == 0;
        }

        public static int OffsetLevel(int level, int rank) {
            //ランクが上がるごとにレベルにオフセット
            return level + (rank - 1) * (rank - 1) * 25;
        }
    }
}
