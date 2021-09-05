using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Linq;
using System;

namespace Ichi.Clicker.Offline
{
    public class LoginRepository : ILoginRepository
    {
        public BigInteger Quantity { get => SaveData.Instance.LoginCommodity.Quantity; }

        public float Percentage {
            get {
                var power = FactoryUtility.SumPower(SaveData.Instance.AutoFactories);
                var count = TimeProducer.Limit.Ticks / TimeProducer.Interval.Ticks;
                var percentage = SaveData.Instance.LoginCommodity.Quantity * 100 / (power * count);
                if (percentage > 100) {
                    return 1f;
                }
                return (float)percentage / 100;
            }
        }

        public void Produce() {
            var now = Common.Time.Now;
            foreach (var factory in SaveData.Instance.AutoFactories) {
                if (factory.IsBought) {
                    TimeProducer.Produce(SaveData.Instance.LoginCommodity, factory.Power, now, ref factory.producedAt);
                }
            }
            SaveData.Instance.Save();
        }

        public void Collect(bool bonus) {
            SaveData.Instance.LoginCommodity.Sell(SaveData.Instance.Coin, bonus ? 2 : 1);
            SaveData.Instance.Save();
        }
    }
}
