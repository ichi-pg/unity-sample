using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System;

namespace Ichi.Clicker
{
    public interface IProducer
    {
        bool Produce(IStore store, BigInteger power, DateTime now);
    }
}
