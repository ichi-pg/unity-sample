using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Common
{
    public static class NumericTextUtility
    {
        private const int digit = 1000;

        public static string Omit(int number) {
            if (number < digit) {
                return number.ToString();
            }
            double omit = number;
            int offset = -1;
            while (omit >= digit) {
                omit /= digit;
                offset++;
            }
            //TODO 'z'以降 ex) 1.02aa
            int alphabet = (int)'a' + offset;
            return omit.ToString("F3") + (char)alphabet;
        }
    }
}
