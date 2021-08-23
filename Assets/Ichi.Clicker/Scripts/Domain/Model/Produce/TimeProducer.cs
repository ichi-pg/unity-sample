using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace Ichi.Clicker
{
    public class TimeProducer : IProducer
    {
        private long interval = 1000;

        public bool Produce(IStore store, BigInteger power, long now, ref long producedAt) {
            if (now < producedAt) {
                return false;
            }
            //TODO リミッター
            //TODO ブースト
            var count = (now - producedAt) / this.interval;
            if (!store.Store(power * count)) {
                return false;
            }
            producedAt = now;
            return true;
        }
    }
}
