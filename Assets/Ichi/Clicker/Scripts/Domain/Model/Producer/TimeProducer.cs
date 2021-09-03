using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System;

namespace Ichi.Clicker
{
    public static class TimeProducer
    {
        public static readonly TimeSpan Interval = TimeSpan.FromSeconds(1);
        public static readonly TimeSpan Limit = TimeSpan.FromHours(12);

        public static void Produce(IStore store, BigInteger power, DateTime now, ref Common.TicksTime producedAt) {
            if (now < producedAt) {
                throw new Exception("Invalid produced at.");
            }
            var span = now - producedAt;
            span = Common.Time.Min(span, Limit);
            var count = span.Ticks / Interval.Ticks;
            store.Store(power * count);
            producedAt = now;
        }
    }
}
