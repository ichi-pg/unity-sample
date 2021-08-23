using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace Ichi.Clicker
{
    [System.Serializable]
    public class Factory : IFactory
    {
        public int level;
        public int rank;
        public int rarity;
        public int category;
        public long producedAt;
        public ILevelCalculator PowerCalculator { private get; set; }
        public ILevelCalculator CostCalculator { private get; set; }
        public ILevelCalculator PriceCalculator { private get; set; }
        public IProducer Producer { private get; set; }
        public int Level { get => this.level; }
        public int Rank { get => this.rank; }
        public int Category { get => this.category; }
        public bool IsLocked { get => this.level <= 0; }
        public BigInteger Power { get => this.PowerCalculator.Calculate(this.level, this.rank, this.rarity); }
        public BigInteger NextPower { get => this.PowerCalculator.Calculate(this.level + 1, this.rank, this.rarity); }
        public BigInteger Cost { get => this.CostCalculator.Calculate(this.level, this.rank, this.rarity); }
        public BigInteger CostPerformance { get => this.Cost / (this.NextPower - this.Power); }
        public BigInteger Price { get => this.PriceCalculator.Calculate(this.level, this.rank, this.rarity); }

        public void LevelUp(IConsume consume, long now) {
            if (!consume.Consume(this.Cost)) {
                throw new System.Exception("Failed consume.");
            }
            if (this.level <= 0) {
                this.producedAt = now;
            }
            this.level++;
        }

        public bool Sell(IStore store) {
            if (this.IsLocked) {
                return false;
            }
            if (!store.Store(this.Price)) {
                return false;
            }
            this.producedAt = 0;
            this.level = 0;
            return true;
        }

        public void Produce(IStore store, long now) {
            if (this.IsLocked) {
                throw new System.Exception("Locked factory.");
            }
            if (!this.Producer.Produce(store, this.Power, now, ref this.producedAt)) {
                throw new System.Exception("Failed produce.");
            }
        }
    }
}
