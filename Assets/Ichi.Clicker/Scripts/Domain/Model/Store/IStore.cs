using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace Ichi.Clicker
{
    public interface IStore
    {
        bool Store(BigInteger quantity);
    }
}
