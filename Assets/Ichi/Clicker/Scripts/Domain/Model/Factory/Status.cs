using System.Collections;
using System.Collections.Generic;

namespace Ichi.Clicker
{
    public abstract class Status<T>
    {
        protected T Value { get; private set; }
        public T NextValue { get; private set; }
        private ICalculator<T> calculator;

        public Status(ICalculator<T> calculator) {
            this.calculator = calculator;
        }

        public void Calculate(int level = 1, int rank = 1, int rarity = 1) {
            this.Value = this.calculator.Calculate(level, rank, rarity);
            this.NextValue = this.calculator.Calculate(level + 1, rank, rarity);
        }
    }
}
