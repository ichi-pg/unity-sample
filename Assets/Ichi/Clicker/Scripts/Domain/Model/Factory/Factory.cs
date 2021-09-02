using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System;

namespace Ichi.Clicker
{
    [Serializable]
    public class Factory : IFactory
    {
        public int level;
        public int rank;
        public int rarity;
        public int category;
        public Common.TicksTime producedAt;
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
            if (this.IsLock) {
                throw new Exception("Invalid lock.");
            }
            consume.Consume(this.Cost);
            if (!this.IsBought) {
                this.producedAt = now;//TODO IFactoryあるからTimeFactoryとClickFactoryに分けられそう
            }
            this.level++;
            this.Calculate();
        }

        public void Sell(IStore store) {
            if (!this.IsBought) {
                throw new Exception("Invalid bought.");
            }
            store.Store(this.Price);
            this.level = 0;
            this.Calculate();
        }
    }
}
