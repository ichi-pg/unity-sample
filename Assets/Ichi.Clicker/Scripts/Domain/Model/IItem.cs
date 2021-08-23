using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace Ichi.Clicker
{
    public interface IItem
    {
        bool Consume(BigInteger coin);
        bool Add(BigInteger coin);
    }
}
