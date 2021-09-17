using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System;
using UniRx;

namespace Ichi.Clicker
{
    [Serializable]
    public class Factory : IGadget
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
        public BigIntegerStatus Power { get; private set; }
        public BigIntegerStatus Cost { get; private set; }
        public GadgetCategory Category { get => GadgetCategory.Factory; }
        private Subject<int> onLevelUp;
        public IObservable<int> OnLevelUp { get => this.onLevelUp; }

        public Factory(int rank) {
            this.rank = rank;
            this.rarity = 1;
            this.Initialize();
        }

        public void PreSave() {
            this.producedAt.PreSave();
        }

        public void PostLoad() {
            this.producedAt.PostLoad();
            this.Initialize();
        }

        private void Initialize() {
            this.onLevelUp = new Subject<int>();
            this.Power = new BigIntegerStatus(new PowerCalculator());
            this.Cost = new BigIntegerStatus(new CostCalculator());
            this.Calculate();
        }

        private void Calculate() {
            this.Power.Calculate(this.level, this.rank, this.rarity);
            this.Cost.Calculate(this.level, this.rank, this.rarity);
        }

        public void LevelUp(IConsume consume) {
            if (this.IsLock) {
                throw new Exception("Invalid lock.");
            }
            consume.Consume(this.Cost);
            this.level++;
            this.Calculate();
            this.onLevelUp.OnNext(this.level);
        }

        public void RarityUp(DateTime now) {
            if (this.IsLock) {
                this.level = 1;
                this.producedAt = now;
            } else {
                this.rarity++;
            }
            this.Calculate();
        }

        public BigInteger Produce(IStore store, DateTime now, int bonus = 1) {
            if (now < this.producedAt) {
                throw new Exception("Invalid produced at.");
            }
            var span = now - this.producedAt;
            span = Common.Time.Min(span, Limit);
            var count = span.Ticks / Interval.Ticks;
            var power = this.Power * count * bonus;
            store.Store(power);
            this.producedAt = now;
            return power;
        }
    }
}
