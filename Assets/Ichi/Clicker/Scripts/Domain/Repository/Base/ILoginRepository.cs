using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System;

namespace Ichi.Clicker
{
    public interface ILoginRepository
    {
        BigInteger Quantity { get; }
        int Percentage { get; }
        void Produce();
        void Collect(bool bonus);
    }
}
