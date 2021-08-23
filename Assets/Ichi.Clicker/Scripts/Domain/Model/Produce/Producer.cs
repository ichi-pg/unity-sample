using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace Ichi.Clicker
{
    public class Producer : IProducer
    {
        public bool Produce(IStore store, BigInteger power, long now, ref long producedAt) {
            return store.Store(power);
        }
    }
}
