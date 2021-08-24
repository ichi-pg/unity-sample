using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace Ichi.Clicker
{
    public class ClickerCostCalculator : ILevelCalculator
    {
        public BigInteger Calculate(int level, int rank, int rarity) {
            return CostCalculator.CostCalculate(ClickerPowerCalculator.PowerCalculate(level), level);
        }
    }
}
