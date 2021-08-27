using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System;

namespace Ichi.Clicker
{
    public interface ILoginRepository
    {
        BigInteger Quanity { get; }
        float Percentage { get; }
        void Produce();
        void Collect(bool bonus);
    }
}
