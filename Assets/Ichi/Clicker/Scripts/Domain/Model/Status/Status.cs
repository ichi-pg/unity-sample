using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System;

namespace Ichi.Clicker
{
    public class Status<T>
    {
        public T Value { get; private set; }
        public T NextValue { get; private set; }
        public IStatusCalculator<T> Calculator { private get; set; }

        public void Calculate(int level, int rank, int rarity) {
            this.Value = this.Calculator.Calculate(level, rank, rarity);
            this.NextValue = this.Calculator.Calculate(level + 1, rank, rarity);
        }
    }
}
