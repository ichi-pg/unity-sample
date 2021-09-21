using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ichi.Clicker.View
{
    public static class GadgetExtensions
    {
        public static string Name(this IGadget gadget) {
            var name = gadget.Rarity() + " " +
                DIContainer.TextLocalizer.Localize(gadget.GadgetCategory.ToString() + gadget.Rank);
            if (gadget.IsBought) {
                return name + " Lv" + gadget.Level + " ";
            }
            return name;
        }

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

        public static string Desc(this IGadget gadget) {
            return DIContainer.TextLocalizer.Localize(gadget.WorkCategory + "Desc", gadget.Power());
        }
    }
}
