using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ichi.Clicker.View
{
    public class GadgetAdapter
    {
        private IGadget gadget;

        public string Name { get => DIContainer.TextLocalizer.Localize(this.gadget.GetType().Name + this.gadget.Rank); }
        public int Rank { get => this.gadget.Rank; }
        public int Level { get => this.gadget.Level; }
        public string Cost { get => Common.BigIntegerText.ToString(this.gadget.Cost); }
        public string Power { get => Common.BigIntegerText.ToString(this.gadget.Power); }
        public string NextPower { get => Common.BigIntegerText.ToString(this.gadget.Power.NextValue); }
        public bool CanLevelUp { get => DIContainer.FromGadgetCategory(this.gadget.Category).CanLevelUp(this.gadget); }
        public string Unit { get => DIContainer.TextLocalizer.Localize(this.gadget.Unit); }

        public GadgetAdapter(IGadget gadget) {
            this.gadget = gadget;
        }
    }
}
