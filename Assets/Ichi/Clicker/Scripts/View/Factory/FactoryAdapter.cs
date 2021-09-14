using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ichi.Clicker.View
{
    public class FactoryAdapter
    {
        private IFactory factory;

        public string Name { get => DIContainer.TextLocalizer.Localize(this.factory.GetType().Name + this.factory.Rank); }
        public int Rank { get => this.factory.Rank; }
        public int Level { get => this.factory.Level; }
        public string Cost { get => Common.BigIntegerText.ToString(this.factory.Cost); }
        public string Power { get => Common.BigIntegerText.ToString(this.factory.Power); }
        public string NextPower { get => Common.BigIntegerText.ToString(this.factory.Power.NextValue); }
        public bool CanLevelUp { get => !this.factory.IsLock && DIContainer.FromItemCategory(this.factory.CostCategory).Item.Quantity >= this.factory.Cost; }
        public string Unit { get => DIContainer.TextLocalizer.Localize(this.factory.Unit); }

        public FactoryAdapter(IFactory factory) {
            this.factory = factory;
        }
    }
}
