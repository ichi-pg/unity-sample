using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System;
using UniRx;

namespace Ichi.Clicker
{
    public interface IGadget : ICost, ILevel
    {
        int Rank { get; }
        int Rarity { get; }
        bool IsBought { get; }
        bool IsLock { get; }
        bool HasLevelUp { get; }
        BigIntegerStatus Power { get; }
        GadgetCategory Category { get; }
        ItemCategory CostCategory { get; }
        IObservable<int> OnLevelUp { get; }
    }
}
