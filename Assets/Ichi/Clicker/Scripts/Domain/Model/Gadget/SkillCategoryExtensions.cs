using System.Collections;
using System.Collections.Generic;
using System;

namespace Ichi.Clicker
{
    public static class SkillCategoryExtensions {

        public static WorkCategory Cast(this SkillCategory category){
            return (WorkCategory)Enum.Parse(typeof(WorkCategory), category.ToString());
        }

        public static SkillCategory Cast(this WorkCategory category){
            return (SkillCategory)Enum.Parse(typeof(SkillCategory), category.ToString());
        }
    }
}
