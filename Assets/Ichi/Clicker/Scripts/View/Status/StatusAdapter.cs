using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace Ichi.Clicker
{
    public class StatusAdapter
    {
        public string Coin { get => Common.BigIntegerText.ToString(DIContainer.CoinRepository.Coin.Quantity); }
        public string Product { get => Common.BigIntegerText.ToString(DIContainer.ProductRepository.Product.Quantity); }

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
