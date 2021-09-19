using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ichi.Clicker.View
{
    public static class GadgetExtensions
    {
        public static string Power(this IGadget gadget) {
            if (gadget.IsBought) {
                return Common.Texts.ToString(gadget.Power);
            }
            return Common.Texts.ToString(gadget.Power.NextValue);
        }

        public static string Cost(this IGadget gadget) {
            return Common.Texts.ToString(gadget.Cost);
        }

        public static bool CanLevelUp(this IGadget gadget) {
            return DIContainer.GadgetRepository.CanLevelUp(gadget);
        }

        public static string CoolTime(this IGadget gadget) {
            switch (gadget.WorkCategory) {
                case WorkCategory.Fever:
                case WorkCategory.CoolDown:
                    return DIContainer.SkillRepository.GetSkill(gadget.WorkCategory.Cast()).CoolTime();
                default:
                    return null;
            }
        }

        public static string Desc(this IGadget gadget) {
            return gadget.CoolTime() ?? DIContainer.TextLocalizer.Localize(gadget.WorkCategory + "Desc", gadget.Power());
        }
    }
}
