using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System;

namespace Ichi.Clicker
{
    public class TimeProducer : IProducer
    {
        private TimeSpan interval = TimeSpan.FromSeconds(1);//TODO ブースト
        private TimeSpan limit = TimeSpan.FromHours(12);//TODO 広告で2倍

        public bool Produce(IStore store, BigInteger power, DateTime now, ref DateTime producedAt) {
            if (now < producedAt) {
                return false;
            }
            var span = now - producedAt;
            if (span > this.limit) {
                span = this.limit;
            }
            var count = span.Ticks / this.interval.Ticks;
            if (!store.Store(power * count)) {
                return false;
            }
            producedAt = now;
            return true;
        }
    }
}
