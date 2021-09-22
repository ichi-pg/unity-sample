using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System;
using System.Threading;
using UniRx;

namespace Ichi.Clicker
{
    public interface IFeverRepository
    {
        void Fever();
        void CheatMode(bool enable);
        IObservable<int> OnAlter { get; }
        IObservable<BigInteger> OnProduce { get; }
    }
}
