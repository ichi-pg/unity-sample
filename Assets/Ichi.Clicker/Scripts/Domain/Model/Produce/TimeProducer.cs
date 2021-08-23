using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace Ichi.Clicker
{
    public class TimeProducer : IProducer
    {
        private long interval = 1000;//TODO ブースト
        private long limit = 12*60*60*1000;//TODO 広告で2倍

        public bool Produce(IStore store, BigInteger power, long now, ref long producedAt) {
            if (now < producedAt) {
                return false;
            }
            var span = now - producedAt;
            if (span > limit) {
                span = limit;
            }
            var count = span / this.interval;
            if (!store.Store(power * count)) {
                return false;
            }
            producedAt = now;
            return true;
        }
    }
}
