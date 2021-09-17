using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ichi.Clicker.View
{
    public static class GadgetExtensions
    {
        public static string Name(this IGadget gadget) {
            var name = DIContainer.TextLocalizer.Localize(gadget.Name);
            if (gadget.Level > 0) {
                return name + " Lv" + gadget.Level;
            }
            return name;
        }

        public static string PowerString(this IGadget gadget) {
            if (gadget.Level > 0) {
                return Common.Texts.ToString(gadget.Power);
            }
            return Common.Texts.ToString(gadget.Power.NextValue);
        }

        public static bool CanLevelUp(this IGadget gadget) {
            return DIContainer.FromGadgetCategory(gadget.Category).CanLevelUp(gadget);
        }
    }
}
