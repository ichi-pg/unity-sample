using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System;
using UniRx;

namespace Ichi.Clicker
{
    [Serializable]
    public class Clicker : IFactory, Common.IPostLoad
    {
        public int level;
        public int rank;
        public int Rarity { get => 1; }
        public int Level { get => this.level; }
        public int Rank { get => this.rank; }
        public bool IsBought { get => this.level > 0; }
        public bool IsLock { get => false; }
        public BigIntegerStatus Power { get; private set; }
        public BigIntegerStatus Cost { get; private set; }
        public string Unit { get => "Click"; }
        public FactoryCategory Category { get => FactoryCategory.Clicker; }
        private Subject<int> onLevelUp;
        public IObservable<int> OnLevelUp { get => this.onLevelUp; }

        public Clicker(int rank) {
            if (rank == 1) {
                this.level = 1;
            }
            this.rank = rank;
            this.Initialize();
        }

        public void PostLoad() {
            this.Initialize();
        }

        private void Initialize() {
            this.onLevelUp = new Subject<int>();
            this.Power = new BigIntegerStatus(new PowerCalculator());
            this.Cost = new BigIntegerStatus(new CostCalculator());
            this.Calculate();
        }

        private void Calculate() {
            this.Power.Calculate(this.level, this.rank);
            this.Cost.Calculate(this.level, this.rank);
        }

        public void LevelUp(IConsume consume) {
            consume.Consume(this.Cost);
            this.level++;
            this.Calculate();
            this.onLevelUp.OnNext(this.level);
        }
    }
}
