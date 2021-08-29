using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System;

namespace Ichi.Clicker
{
    public interface IItem
    {
        BigInteger Quantity { get; }
        event Action AlterHandler;
    }
}
