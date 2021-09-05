using System.Collections;
using System.Collections.Generic;
using System;

namespace Ichi.Common
{
    public static class Time
    {
        //TODO チート対策（自前NTPと負荷対策）
        public static DateTime Now { get => DateTime.Now; }
        public static TimeSpan Max(TimeSpan a, TimeSpan b)  => a > b ? a : b;
        public static TimeSpan Min(TimeSpan a, TimeSpan b)  => a < b ? a : b;
        public static DateTime Max(DateTime a, DateTime b)  => a > b ? a : b;
        public static DateTime Min(DateTime a, DateTime b)  => a < b ? a : b;
    }
}
