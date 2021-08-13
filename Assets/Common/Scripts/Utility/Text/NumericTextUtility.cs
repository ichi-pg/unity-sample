using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Common
{
    public static class NumericTextUtility
    {
        public static string Omit(int number) {
            int omit = -1;
            while (number >= 1000) {
                number /= 1000;
                omit++;
            }
            if (omit < 0) {
                return number.ToString();
            }
            int alphabet = (int)'a' + omit;
            return number.ToString() + (char)alphabet;
        }

        //TODO 'z'以降は？
    }
}
