using System.Collections;
using System.Collections.Generic;
using System;

namespace Ichi.Common
{
    public static class Time
    {
        //TODO チート対策（NTP or 起動時間）
        public static long Now { get => DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond; }
    }
}
