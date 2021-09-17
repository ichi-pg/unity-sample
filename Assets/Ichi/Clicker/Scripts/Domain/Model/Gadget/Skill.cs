using System.Collections;
using System.Collections.Generic;
using System;
using UniRx;

namespace Ichi.Clicker
{
    [Serializable]
    public class Skill : IGadget, ILevelUpper
    {
        public SkillCategory category;
        public Common.TicksTime coolDownAt;
        public int level;
        public DateTime FinishAt { get; set; }
        public int Level { get => this.level; set => this.level = value; }
        public int Rank { get => (int)this.category + 1; }
        public int Rarity { get => 1; }
        public bool IsBought { get => true; }
        public bool IsLock { get => false; }
        public bool HasLevelUp { get => true; }
        public BigIntegerStatus Power { get; private set; }
        public BigIntegerStatus Cost { get; private set; }
        public GadgetCategory Category { get => GadgetCategory.Skill; }
        public ItemCategory CostCategory { get => ItemCategory.Gem; }
        private Subject<int> onLevelUp;
        public IObservable<int> OnLevelUp { get => this.onLevelUp; }
        public IObserver<int> LevelUpObserver { get => this.onLevelUp; }

        public Skill(SkillCategory category) {
            this.category = category;
            this.level = 1;
            this.Initialize();
        }

        public void PreSave() {
            this.coolDownAt.PreSave();
        }

        public void PostLoad() {
            this.coolDownAt.PostLoad();
            this.Initialize();
        }

        private void Initialize() {
            this.onLevelUp = new Subject<int>();
            this.Power = new BigIntegerStatus(new PowerCalculator());
            this.Cost = new BigIntegerStatus(new CostCalculator());
            this.Calculate();
        }

        public TimeSpan CoolTime(DateTime now) {
            return Common.Time.Max(this.coolDownAt - now, TimeSpan.Zero);
        }

        public TimeSpan TimeLeft(DateTime now) {
            return Common.Time.Max(this.FinishAt - now, TimeSpan.Zero);
        }
    }
}
