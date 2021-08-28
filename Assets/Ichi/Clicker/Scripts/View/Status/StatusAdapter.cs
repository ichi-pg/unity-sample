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
        public string Coin { get => Common.BigIntegerText.ToString(DIContainer.CoinRepository.Coin.Quantity); }
        public string Product { get => Common.BigIntegerText.ToString(DIContainer.ProductRepository.Product.Quantity); }
        //TODO フィーバーレート表示
        //TODO フィーバー残り時間表示
        //TODO フィーバークールタイム表示

        public string ClickPower {
            get {
                var power = FactoryUtility.SumPower(DIContainer.FactoryRepository.ClickFactories);
                return Common.BigIntegerText.ToString(power);
            }
        }

        public string AutoPower {
            get {
                var power = FactoryUtility.SumPower(DIContainer.FactoryRepository.AutoFactories);
                return Common.BigIntegerText.ToString(power);
            }
        }
    }
}
