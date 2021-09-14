using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System;

namespace Ichi.Clicker
{
    public interface IFactory : ICost, ILevel
    {
        int Rank { get; }
        int Rarity { get; }
        bool IsBought { get; }
        bool IsLock { get; }
        BigIntegerStatus Power { get; }
        string Unit { get; }
        FactoryCategory Category { get; }
        ItemCategory CostCategory { get; }
        event Action AlterHandler;
    }
}
