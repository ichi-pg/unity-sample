using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System;

namespace Ichi.Clicker
{
    public interface ILoginRepository
    {
        BigInteger Quanity { get; }
        int Percentage { get; }
        void PreProduce();
        void Produce(bool bonus);
    }
}
