using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System;
using UniRx;

namespace Ichi.Clicker
{
    public interface IProduceRepository : IGadgetRepository
    {
        void Produce();
        void CheatMode(bool enable);
        IObservable<BigInteger> OnProduce { get; }
    }
}
