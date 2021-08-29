using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace Ichi.Common
{
    public static class BigIntegerText
    {
        public static string ToString(BigInteger number) {
            BigInteger remainder = 0;
            int i = 0;
            while (number >= 1000) {
                remainder = number % 1000;
                number /= 1000;
                i++;
            }
            string units = "";
            while (i > 0) {
                int unit = (int)'A' + (i % 26) - 1;
                units = ((char)unit).ToString() + units;
                i /= 26;
            }
            //TODO 桁が上がると変化量見えなくなるので、やっぱり長いパターン必要
            return number + "." + (remainder / 100) + units;
        }
    }
}
