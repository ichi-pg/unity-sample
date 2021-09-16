using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System;
using UniRx;

namespace Ichi.Clicker
{
    public interface IGadgetRepository
    {
        IEnumerable<IGadget> Factories { get; }
        bool CanLevelUp(IGadget gadget);
        void LevelUp(IGadget gadget);
        void Produce();
        void CheatMode(bool enable);
        IObservable<BigInteger> OnProduce { get; }
    }
}
