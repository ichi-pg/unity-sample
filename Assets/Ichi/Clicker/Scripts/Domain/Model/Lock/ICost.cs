using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace Ichi.Clicker
{
    public interface ICost
    {
        BigIntegerStatus Cost { get; }
    }
}
