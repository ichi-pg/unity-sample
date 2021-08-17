using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace Common
{
    public static class BigIntegerText
    {
        public static string ToString(BigInteger number, bool shortening = true, char alphabet = 'A') {
            BigInteger remainder = 0;
            int i = 0;
            while (number >= 1000) {
                remainder = number % 1000;
                number /= 1000;
                i++;
            }
            string units = "";
            while (i > 0) {
                int unit = (int)alphabet + (i % 26) - 1;
                units += ((char)unit).ToString();
                i /= 26;
            }
            if (shortening) {
                return number + "." + (remainder / 1000) + units;
            }
            if (remainder > 0) {
                return number + "." + remainder.ToString("D3").TrimEnd('0') + units;
            }
            return number + units;
        }
    }
}
