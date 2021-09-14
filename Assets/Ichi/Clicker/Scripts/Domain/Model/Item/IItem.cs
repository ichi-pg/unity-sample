using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System;
using UniRx;

namespace Ichi.Clicker
{
    public interface IItem
    {
        BigInteger Quantity { get; }
        IObservable<BigInteger> OnAlter { get; }
    }
}
