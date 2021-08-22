using System.Collections;
using System.Collections.Generic;
using System;

namespace Ichi.Common
{
    public static class Time
    {
        public static long Now { get => DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond; } //TODO チート対策
    }
}
