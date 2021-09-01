using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System;

namespace Ichi.Clicker
{
    [Serializable]
    public class Factory : IFactory, IProducedAt
    {
        public int level;
        public int rank;
        public int rarity;
        public int category;
        public Common.TicksTime producedAt;
        public Common.TicksTime ProducedAt { get => this.producedAt; set => this.producedAt = value; }
        public IStatusCalculator<BigInteger> PowerCalculator { private get; set; }
        public IStatusCalculator<BigInteger> CostCalculator { private get; set; }
        public IProducer Producer { private get; set; }
        public ILock Lock { private get; set; }
        public int Level { get => this.level; }
        public int Rank { get => this.rank; }
        public int Category { get => this.category; }
        public bool IsLock { get => this.Lock.IsLock; }
        public bool IsBought { get => this.level > 0; }
        public BigInteger Power { get; private set; }
        public BigInteger NextPower { get; private set; }
        public BigInteger Cost { get; private set; }
        public BigInteger Price { get; private set; }
        public event Action AlterHandler;

        public Factory() {
            this.producedAt = new Common.TicksTime();
        }

        public void Calculate() {
            this.Power = this.PowerCalculator.Calculate(this.level, this.rank, this.rarity);
            this.NextPower = this.PowerCalculator.Calculate(this.level + 1, this.rank, this.rarity);
            this.Cost = this.CostCalculator.Calculate(this.level, this.rank, this.rarity);
            this.AlterHandler?.Invoke();
        }

        public void LevelUp(IConsume consume, DateTime now) {
            if (!consume.Consume(this.Cost)) {
                throw new Exception("Failed consume.");
            }
            if (!this.IsBought) {
                this.ProducedAt = now;
            }
            this.level++;
            this.Calculate();
        }

        public bool Sell(IStore store) {
            if (!this.IsBought) {
                return false;
            }
            if (!store.Store(this.Price)) {
                return false;
            }
            this.level = 0;
            this.Calculate();
            return true;
        }

        public void Produce(IStore store, DateTime now, int bonus = 1) {
            if (!this.IsBought) {
                throw new Exception("Not bought factory.");
            }
            if (!this.Producer.Produce(store, this.Power * bonus, now)) {
                throw new Exception("Failed produce.");
            }
        }
    }
}
