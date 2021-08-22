using System.Collections;
using System.Collections.Generic;

namespace Ichi.Common
{
    public static class Time
    {
        public static long Now { get => System.DateTime.Now.Ticks / System.TimeSpan.TicksPerMillisecond; } //TODO チート対策
    }
}
