
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System;
using UniRx;

namespace Ichi.Clicker
{
    public static class LevelUpperExtensions
    {
        public static void Calculate(this ILevelUpper upper) {
            upper.Power.Calculate(upper.Level, upper.Rank, upper.Rarity);
            upper.Cost.Calculate(upper.Level, upper.Rank, upper.Rarity);
        }

        public static void LevelUp(this ILevelUpper upper, IConsume consume) {
            if (upper.IsLock) {
                throw new Exception("Invalid lock.");
            }
            consume.Consume(upper.Cost);
            upper.Level++;
            upper.Calculate();
            upper.LevelUpObserver.OnNext(upper.Level);
        }
    }
}
