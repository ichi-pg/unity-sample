using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ichi.Clicker.View
{
    public static class GadgetExtensions
    {
        public static string Power(this IGadget gadget) {
            if (gadget.Level > 0) {
                return Common.Texts.ToString(gadget.Power);
            }
            return Common.Texts.ToString(gadget.Power.NextValue);
        }

        public static string Cost(this IGadget gadget) {
            return Common.Texts.ToString(gadget.Cost);
        }

        public static bool CanLevelUp(this IGadget gadget) {
            return DIContainer.FromGadgetCategory(gadget.Category).CanLevelUp(gadget);
        }

        public static string LevelUp(this IGadget gadget) {
            return DIContainer.TextLocalizer.Localize(gadget.IsBought ? "LevelUp" : "Buy");
        }
    }
}
