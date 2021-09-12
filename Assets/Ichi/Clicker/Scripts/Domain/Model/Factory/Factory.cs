using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System;

namespace Ichi.Clicker
{
    [Serializable]
    public class Factory : IFactory
    {
        public static readonly TimeSpan Interval = TimeSpan.FromSeconds(1);
        public static readonly TimeSpan Limit = TimeSpan.FromHours(12);

        public int level;
        public int rank;
        public int rarity;
        public bool isLock;
        public Common.TicksTime producedAt;
        public int Level { get => this.level; }
        public int Rank { get => this.rank; }
        public int Rarity { get => this.rarity; }
        public bool IsBought { get => this.level > 0; }
        public bool IsLock { get => this.isLock; }
        public BigIntegerStatus Power { get; set; }
        public BigIntegerStatus Cost { get; set; }
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
                this.producedAt = now;
            }
            this.level++;
            this.Calculate();
        }

        public void Produce(IStore store, DateTime now, int bonus = 1) {
            if (now < this.producedAt) {
                throw new Exception("Invalid produced at.");
            }
            var span = now - this.producedAt;
            span = Common.Time.Min(span, Limit);
            var count = span.Ticks / Interval.Ticks;
            store.Store(this.Power * count * bonus);
            this.producedAt = now;
        }
    }
}
