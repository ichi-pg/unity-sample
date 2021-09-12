using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Ichi.Clicker
{
    public class FactoryAdapter
    {
        private IFactory factory;

        public string Name { get => DIContainer.TextLocalizer.Localize("Factory" + this.factory.Rank); }
        public int Rank { get => this.factory.Rank; }
        public int Level { get => this.factory.Level; }
        public string Cost { get => Common.BigIntegerText.ToString(this.factory.Cost); }
        public string Power { get => Common.BigIntegerText.ToString(this.factory.Power); }
        public string NextPower { get => Common.BigIntegerText.ToString(this.factory.Power.NextValue); }
        public bool CanLevelUp { get => !this.factory.IsLock && DIContainer.CoinRepository.Coin.Quantity >= this.factory.Cost; }
        public string Unit { get => DIContainer.TextLocalizer.Localize("Seconds"); }

        public FactoryAdapter(IFactory factory) {
            this.factory = factory;
        }
    }
}
