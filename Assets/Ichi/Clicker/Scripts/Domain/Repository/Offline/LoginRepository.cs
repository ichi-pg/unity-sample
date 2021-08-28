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
            foreach (var factory in SaveData.Instance.AutoFactories) {
                if (factory.IsBought) {
                    factory.Produce(SaveData.Instance.LoginProduct, Common.Time.Now);
                }
            }
        }

        public void Collect(bool bonus) {
            SaveData.Instance.LoginProduct.Sell(SaveData.Instance.Coin, bonus ? 2 : 1);
        }
    }
}
