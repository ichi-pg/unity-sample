using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace Ichi.Clicker
{
    public interface IProducer
    {
        bool Produce(IStore store, BigInteger power, long now, ref long producedAt);
    }
}
