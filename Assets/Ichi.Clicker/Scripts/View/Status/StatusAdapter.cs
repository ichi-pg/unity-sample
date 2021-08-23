using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace Ichi.Clicker
{
    public class StatusAdapter
    {
        public string CoinText { get => Dependency.LocalizationText.Localize("Status.Coin", this); }
        public string ProductText { get => Dependency.LocalizationText.Localize("Status.Product", this); }
        public string ClickPowerText { get => Dependency.LocalizationText.Localize("Status.ClickPower", this); }
        public string AutoPowerText { get => Dependency.LocalizationText.Localize("Status.AutoPower", this); }
        public string Coin { get => Ichi.Common.BigIntegerText.ToString(Dependency.ItemRepository.Coin.Quantity); }
        public string Product { get => Ichi.Common.BigIntegerText.ToString(Dependency.ItemRepository.Product.Quantity); }

        public string ClickPower {
            get {
                BigInteger power;
                foreach (var factory in Dependency.FactoryRepository.ClickFactories) {
                    power += factory.Power;
                }
                return Ichi.Common.BigIntegerText.ToString(power);
            }
        }

        public string AutoPower {
            get {
                BigInteger power;
                foreach (var factory in Dependency.FactoryRepository.AutoFactories) {
                    power += factory.Power;
                }
                return Ichi.Common.BigIntegerText.ToString(power);
            }
        }
    }
}
