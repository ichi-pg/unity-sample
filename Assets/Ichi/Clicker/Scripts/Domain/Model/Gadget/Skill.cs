using System.Collections;
using System.Collections.Generic;
using System;

namespace Ichi.Clicker
{
    [Serializable]
    public class Skill
    {
        public SkillCategory category;
        public Common.TicksTime coolDownAt;
        public DateTime FinishAt { get; set; }

        public Skill(SkillCategory category) {
            this.category = category;
        }

        public void PreSave() {
            this.coolDownAt.PreSave();
        }

        public void PostLoad() {
            this.coolDownAt.PostLoad();
        }

        public TimeSpan CoolTime(DateTime now) {
            return Common.Time.Max(this.coolDownAt - now, TimeSpan.Zero);
        }

        public TimeSpan TimeLeft(DateTime now) {
            return Common.Time.Max(this.FinishAt - now, TimeSpan.Zero);
        }
    }
}
