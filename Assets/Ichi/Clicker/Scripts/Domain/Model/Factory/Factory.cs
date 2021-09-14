using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System;
using UniRx;

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
        public Common.TicksTime producedAt;
        public int Level { get => this.level; }
        public int Rank { get => this.rank; }
        public int Rarity { get => this.rarity; }
        public bool IsBought { get => this.level > 0; }
        public bool IsLock { get => this.level == 0; }
        public BigIntegerStatus Power { get; set; }
        public BigIntegerStatus Cost { get; set; }
        public string Unit { get => "Seconds"; }
        public FactoryCategory Category { get => FactoryCategory.Factory; }
        public Subject<int> onLevelUp;
        public IObservable<int> OnLevelUp { get => this.onLevelUp; }

        public void Calculate() {
            this.Power.Calculate(this.level, this.rank, this.rarity);
            this.Cost.Calculate(this.level, this.rank, this.rarity);
            this.onLevelUp.OnNext(this.level);
        }

        public void LevelUp(IConsume consume) {
            if (this.IsLock) {
                throw new Exception("Invalid lock.");
            }
            consume.Consume(this.Cost);
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
