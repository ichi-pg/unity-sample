using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System;

namespace Ichi.Clicker
{
    public class Producer : IProducer
    {
        public bool Produce(IStore store, BigInteger power, DateTime now, ref DateTime producedAt) {
            return store.Store(power);
        }
    }
}
