using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System;

namespace Ichi.Clicker
{
    [System.Serializable]
    public class Factory : IFactory
    {
        public int level;
        public int rank;
        public int rarity;
        public int category;
        public long producedTicks;
        public ILevelCalculator PowerCalculator { private get; set; }
        public ILevelCalculator CostCalculator { private get; set; }
        public IProducer Producer { private get; set; }
        public int Level { get => this.level; }
        public int Rank { get => this.rank; }
        public int Category { get => this.category; }
        public bool IsLocked { get => this.level <= 0; }
        public int FeverRate { get => this.CalculateFeverRate(this.Level); }
        public int NextFeverRate { get => this.CalculateFeverRate(this.Level + 1); }
        public BigInteger Power { get; private set; }
        public BigInteger NextPower { get; private set; }
        public BigInteger Cost { get; private set; }
        public BigInteger CostPerformance { get; private set; }
        public BigInteger Price { get; private set; }

        public DateTime ProducedAt {
            get => new DateTime(this.producedTicks);
            set => this.producedTicks = value.Ticks;
        }

        private int CalculateFeverRate(int level) {
            return level / 50 + 1;//TODO 調整
        }

        public void Calculate() {
            this.Power = this.PowerCalculator.Calculate(this.level, this.rank, this.rarity);
            this.NextPower = this.PowerCalculator.Calculate(this.level + 1, this.rank, this.rarity);
            this.Cost = this.CostCalculator.Calculate(this.level, this.rank, this.rarity);
            this.CostPerformance = this.Cost / (this.NextPower - this.Power);
        }

        public void LevelUp(IConsume consume, DateTime now) {
            if (!consume.Consume(this.Cost)) {
                throw new System.Exception("Failed consume.");
            }
            if (this.IsLocked) {
                this.ProducedAt = now;
            }
            this.level++;
            this.Calculate();
        }

        public bool Sell(IStore store) {
            if (this.IsLocked) {
                return false;
            }
            if (!store.Store(this.Price)) {
                return false;
            }
            this.level = 0;
            return true;
        }

        public void Produce(IStore store, DateTime now, int bonus = 1) {
            if (this.IsLocked) {
                throw new System.Exception("Locked factory.");
            }
            var producedAt = this.ProducedAt;
            if (!this.Producer.Produce(store, this.Power * bonus, now, ref producedAt)) {
                throw new System.Exception("Failed produce.");
            }
            this.ProducedAt = producedAt;
        }
    }
}
