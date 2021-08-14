using System.Collections;
using System.Collections.Generic;

namespace Common
{
    public static class NumericTextUtility
    {
        public static string Omit(int number) {
            double result = number;
            int i = 0;
            while (result >= 1000) {
                result /= 1000;
                i++;
            }
            string units = "";
            while (i > 0) {
                int unit = (int)'a' + (i % 26) - 1;
                units += ((char)unit).ToString();
                i /= 26;
            }
            return result.ToString("F3").TrimEnd('0').TrimEnd('.') + units;
        }
    }
}
