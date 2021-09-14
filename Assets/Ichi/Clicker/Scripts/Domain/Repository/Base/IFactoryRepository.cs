using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System;
using UniRx;

namespace Ichi.Clicker
{
    public interface IFactoryRepository
    {
        IEnumerable<IFactory> Factories { get; }
        bool CanLevelUp(IFactory factory);
        void LevelUp(IFactory factory);
        void Produce();
        void CheatMode(bool enable);
        IObservable<BigInteger> OnProduce { get; }
    }
}
