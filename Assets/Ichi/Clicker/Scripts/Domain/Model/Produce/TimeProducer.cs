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

        private IProducedAt self;

        public TimeProducer(IProducedAt self) {
            this.self = self;
        }

        public bool Produce(IStore store, BigInteger power, DateTime now) {
            if (now < this.self.ProducedAt) {
                return false;
            }
            var span = now - this.self.ProducedAt;
            if (span > Limit) {
                span = Limit;
            }
            var count = span.Ticks / Interval.Ticks;
            if (!store.Store(power * count)) {
                return false;
            }
            this.self.ProducedAt = now;
            return true;
        }
    }
}
