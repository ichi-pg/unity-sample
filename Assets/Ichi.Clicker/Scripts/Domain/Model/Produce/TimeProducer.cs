using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System;

namespace Ichi.Clicker
{
    public class TimeProducer : IProducer
    {
        private static readonly TimeSpan Interval = TimeSpan.FromSeconds(1);
        private static readonly TimeSpan Limit = TimeSpan.FromHours(12);

        public bool Produce(IStore store, BigInteger power, DateTime now, ref DateTime producedAt) {
            if (now < producedAt) {
                return false;
            }
            var span = now - producedAt;
            if (span > Limit) {
                span = Limit;
            }
            var count = span.Ticks / Interval.Ticks;
            if (!store.Store(power * count)) {
                return false;
            }
            producedAt = now;
            return true;
        }

        //TODO ブースト
        //TODO 広告で2倍
        //TODO チートモード（100倍速）
    }
}
