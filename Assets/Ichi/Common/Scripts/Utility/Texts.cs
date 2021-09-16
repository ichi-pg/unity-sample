using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace Ichi.Common
{
    public static class Texts
    {
        public static string ToString(BigInteger number) {
            BigInteger remainder = 0;
            int i = 0;
            while (number >= 1000) {
                remainder = number % 1000;
                number /= 1000;
                i++;
            }
            var units = "";
            while (i > 0) {
                int unit = (int)'A' + (i % 26) - 1;
                units = ((char)unit).ToString() + units;
                i /= 26;
            }
            var rem = "." + remainder.ToString("000");
            // var rem = "." + (remainder / 100);
            rem = rem.TrimEnd('0').TrimEnd('.');
            return number + rem + units;
        }
    }
}
