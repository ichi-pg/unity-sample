using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Linq;
using System;

namespace Ichi.Clicker.Offline
{
    public class LoginRepository : ILoginRepository
    {
        public BigInteger Quantity { get => SaveData.Instance.LoginProduct.Quantity; }

        public int Percentage {
            get {
                var power = FactoryUtility.SumPower(SaveData.Instance.AutoFactories);
                var count = TimeProducer.Limit.Ticks / TimeProducer.Interval.Ticks;
                return (int)(SaveData.Instance.LoginProduct.Quantity * 100 / (power * count));
            }
        }

        public void Produce() {
            var now = Common.Time.Now;
            foreach (var factory in SaveData.Instance.AutoFactories) {
                if (factory.IsBought) {
                    TimeProducer.Produce(SaveData.Instance.Coin, factory.Power, now, ref factory.producedAt);
                }
            }
            SaveData.Instance.Save();
        }

        public void Collect(bool bonus) {
            SaveData.Instance.LoginProduct.Sell(SaveData.Instance.Coin, bonus ? 2 : 1);
            SaveData.Instance.Save();
        }
    }
}
