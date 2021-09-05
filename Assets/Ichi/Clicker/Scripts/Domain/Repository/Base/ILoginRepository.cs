using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System;

namespace Ichi.Clicker
{
    public interface ILoginRepository
    {
        BigInteger Quantity { get; }
        float QuantityRate { get; }
        void Produce();
        void Collect(bool bonus);
    }
}
