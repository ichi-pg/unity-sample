using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System;

namespace Ichi.Clicker
{
    [Serializable]
    public class Clicker : IFactory
    {
        public int level;
        public int rank;
        public int Rarity { get => 1; }
        public int Level { get => this.level; }
        public int Rank { get => this.rank; }
        public bool IsBought { get => this.level > 0; }
        public bool IsLock { get => false; }
        public BigIntegerStatus Power { get; set; }
        public BigIntegerStatus Cost { get; set; }
        public string Unit { get => "Click"; }
        public FactoryCategory Category { get => FactoryCategory.Clicker; }
        public ItemCategory CostCategory { get => ItemCategory.Coin; }
        public event Action AlterHandler;

        public void Calculate() {
            this.Power.Calculate(this.level, this.rank);
            this.Cost.Calculate(this.level, this.rank);
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
