
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System;

namespace Ichi.Clicker
{
    public static class StatusLinq
    {
        public static BigInteger Sum<T>(this IEnumerable<T> list, Func<T, BigIntegerStatus> selector) {
            BigInteger res;
            foreach (var i in list) {
                res += selector(i);
            }
            return res;
        }
    }
}
