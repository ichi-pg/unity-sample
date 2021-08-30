using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Ichi.Clicker
{
    public class FactoryAdapter
    {
        private IFactory factory;

        public int Rank { get => this.factory.Rank; }
        public int Level { get => this.factory.Level; }
        public string Cost { get => Common.BigIntegerText.ToString(this.factory.Cost); }
        public string Power { get => Common.BigIntegerText.ToString(this.factory.Power); }
        public string NextPower { get => Common.BigIntegerText.ToString(this.factory.NextPower); }
        public bool CanLevelUp { get => !this.factory.IsLock && DIContainer.CoinRepository.Coin.Quantity >= this.factory.Cost; }

        public string Unit {
            get {
                switch (this.factory.Category) {
                    case (int)FactoryCategory.Click:
                        return DIContainer.TextLocalizer.Localize("Unit.Click");
                    case (int)FactoryCategory.Auto:
                        return DIContainer.TextLocalizer.Localize("Unit.Auto");
                    default:
                        return "";
                }
            }
        }

        public FactoryAdapter(IFactory factory) {
            this.factory = factory;
        }
    }
}
