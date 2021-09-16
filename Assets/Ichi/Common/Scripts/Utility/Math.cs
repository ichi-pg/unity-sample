using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace Ichi.Common
{
    public static class Math
    {
        public static float Divide(BigInteger a, BigInteger b) {
            if (a == 0 || b == 0) {
                return 0f;
            }
            return (float)(a * 100 / b) / 100f;
        }
    }
}
