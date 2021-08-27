using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace Ichi.Clicker
{
    public class StatusAdapter
    {
        public string CoinText { get => DIContainer.TextLocalizer.Localize("Status.Coin", this); }
        public string ProductText { get => DIContainer.TextLocalizer.Localize("Status.Product", this); }
        public string ClickPowerText { get => DIContainer.TextLocalizer.Localize("Status.ClickPower", this); }
        public string AutoPowerText { get => DIContainer.TextLocalizer.Localize("Status.AutoPower", this); }
        public string Coin { get => Ichi.Common.BigIntegerText.ToString(DIContainer.ItemRepository.Coin.Quantity); }
        public string Product { get => Ichi.Common.BigIntegerText.ToString(DIContainer.ItemRepository.Product.Quantity); }
        //TODO フィーバーレート表示

        public string ClickPower {
            get {
                BigInteger power;
                foreach (var factory in DIContainer.FactoryRepository.ClickFactories) {
                    power += factory.Power;
                }
                return Ichi.Common.BigIntegerText.ToString(power);
            }
        }

        public string AutoPower {
            get {
                BigInteger power;
                foreach (var factory in DIContainer.FactoryRepository.AutoFactories) {
                    power += factory.Power;
                }
                return Ichi.Common.BigIntegerText.ToString(power);
            }
        }
    }
}
