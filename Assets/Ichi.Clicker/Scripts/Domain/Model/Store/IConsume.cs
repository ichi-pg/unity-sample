using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace Ichi.Clicker
{
    public interface IConsume
    {
        bool Consume(BigInteger quantity);
    }
}
