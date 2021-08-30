using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace Ichi.Clicker
{
    public static class OffsetLevel
    {
        public static int Calculate(int level, int rank) {
            //ランクが上がるごとにレベルにオフセット
            return level + (rank - 1) * (rank - 1) * 25;
        }
    }
}
