using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System;

namespace Ichi.Clicker
{
    [Serializable]
    public class Clicker : IClicker
    {
        public int level;
        public int rank;
        public int rarity;
        public int Level { get => this.level; }
        public int Rank { get => this.rank; }
        public int Rarity { get => this.rarity; }
        public bool IsBought { get => this.level > 0; }
        public BigIntegerStatus Power { get; set; }
        public BigIntegerStatus Cost { get; set; }
        public event Action AlterHandler;

        public void Calculate() {
            this.Power.Calculate(this.level, this.rank, this.rarity);
            this.Cost.Calculate(this.level, this.rank, this.rarity);
            this.AlterHandler?.Invoke();
        }

        public void LevelUp(IConsume consume) {
            consume.Consume(this.Cost);
            this.level++;
            this.Calculate();
        }

        public void Produce(IStore store, int bonus = 1) {
            store.Store(this.Power * bonus);
        }
    }
}
