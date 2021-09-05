using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System;

namespace Ichi.Clicker
{
    public class StatusAdapter
    {
        public string Coin { get => Common.BigIntegerText.ToString(DIContainer.CoinRepository.Coin.Quantity); }
        public string Commodity { get => Common.BigIntegerText.ToString(DIContainer.CommodityRepository.Commodity.Quantity); }
        public int FeverRate { get => DIContainer.FeverRepository.Rate; }
        public string FeverTimeLeft { get => DIContainer.FeverRepository.TimeLeft.ToString("mm\\:ss"); }
        public string FeverCoolTime { get => DIContainer.FeverRepository.CoolTime.ToString("mm\\:ss"); }
        public string FeverAdsCoolTime { get => DIContainer.FeverRepository.AdsCoolTime.ToString("mm\\:ss"); }

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
