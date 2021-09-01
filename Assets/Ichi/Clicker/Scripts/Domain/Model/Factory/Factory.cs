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
        public IProducer Producer { private get; set; }
        public ILock Lock { private get; set; }
        public int Level { get => this.level; }
        public int Rank { get => this.rank; }
        public int Category { get => this.category; }
        public bool IsLock { get => this.Lock.IsLock; }
        public bool IsBought { get => this.level > 0; }
        public BigIntegerStatus Power { get; set; }
        public BigIntegerStatus Cost { get; set; }
        public BigIntegerStatus Price { get; set; }
        public event Action AlterHandler;

        public void Calculate() {
            this.Power.Calculate(this.level, this.rank, this.rarity);
            this.Cost.Calculate(this.level, this.rank, this.rarity);
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
