using System.Collections;
using System.Collections.Generic;
using System;
using UniRx;

namespace Ichi.Clicker
{
    [Serializable]
    public class Skill : IGadget
    {
        public SkillCategory category;
        public Common.TicksTime coolDownAt;
        public int level;
        public DateTime FinishAt { get; set; }
        public int Level { get => this.level; }
        public int Rank { get => 1; }
        public int Rarity { get => 1; }
        public bool IsBought { get => true; }
        public bool IsLock { get => false; }
        public BigIntegerStatus Power { get; private set; }
        public BigIntegerStatus Cost { get; private set; }
        public string Name { get => "Skill" + this.category; }
        public string Store { get => ""; }
        public string Unit { get => ""; }
        public GadgetCategory Category { get => GadgetCategory.Skill; }
        private Subject<int> onLevelUp;
        public IObservable<int> OnLevelUp { get => this.onLevelUp; }

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
            //NEXT 共通化可能
        }

        private void Calculate() {
            this.Power.Calculate(this.level);
            this.Cost.Calculate(this.level);
            //NEXT 共通化可能
        }

        public TimeSpan CoolTime(DateTime now) {
            return Common.Time.Max(this.coolDownAt - now, TimeSpan.Zero);
        }

        public TimeSpan TimeLeft(DateTime now) {
            return Common.Time.Max(this.FinishAt - now, TimeSpan.Zero);
        }

        public void LevelUp(IConsume consume) {
            if (this.IsLock) {
                throw new Exception("Invalid lock.");
            }
            consume.Consume(this.Cost);
            this.level++;
            this.Calculate();
            this.onLevelUp.OnNext(this.level);
            //NEXT 共通化可能
        }
    }
}
