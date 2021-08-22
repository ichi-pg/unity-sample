using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace Ichi.Clicker
{
    public class StatusAdapter
    {
        public string CoinText { get => Dependency.LocalizationText.Localize("Status.Coin", this); }
        public string PowerText { get => Dependency.LocalizationText.Localize("Status.Power", this); }
        public string Coin { get => Ichi.Common.BigIntegerText.ToString(Dependency.ItemRepository.Get(Item.Categories.Coin).Quantity); }
        public string Power {
            get {
                BigInteger power;
                foreach (var factory in Dependency.FactoryRepository.List(Factory.Categories.Auto)) {
                    power += factory.Power;
                }
                return Ichi.Common.BigIntegerText.ToString(power);
            }
        }
    }
}
