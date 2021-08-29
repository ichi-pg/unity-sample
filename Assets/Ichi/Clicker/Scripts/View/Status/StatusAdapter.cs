using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System;

namespace Ichi.Clicker
{
    public class StatusAdapter
    {
        public string Coin { get => Common.BigIntegerText.ToString(DIContainer.CoinRepository.Coin.Quantity); }
        public string Product { get => Common.BigIntegerText.ToString(DIContainer.ProductRepository.Product.Quantity); }
        public int FeverRate { get => DIContainer.FeverRepository.Rate; }
        public TimeSpan FeverTimeLeft { get => DIContainer.FeverRepository.TimeLeft; }
        public TimeSpan FeverCoolTime { get => DIContainer.FeverRepository.CoolTime; }
        public TimeSpan FeverAdsCoolTime { get => DIContainer.FeverRepository.AdsCoolTime; }

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
