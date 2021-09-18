using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System;
using UniRx;

namespace Ichi.Clicker
{
    public interface ILevelUpper
    {
        int Level { get; set; }
        int Rank { get; }
        int Rarity { get; }
        bool HasLevelUp { get; }
        BigIntegerStatus Power { get; }
        BigIntegerStatus Cost { get; }
        IObserver<int> LevelUpObserver { get; }
    }
}
