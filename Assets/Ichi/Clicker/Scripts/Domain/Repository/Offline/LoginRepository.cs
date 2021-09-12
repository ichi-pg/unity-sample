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
        private ITimeRepository timeRepository;

        public float QuantityRate {
            get {
                var power = SaveData.Instance.factories.Sum(factory => factory.Power);
                var count = Factory.Limit.Ticks / Factory.Interval.Ticks;
                var rate = SaveData.Instance.LoginCommodity.Quantity * 100 / (power * count);
                if (rate > 100) {
                    return 1f;
                }
                return (float)rate / 100;
            }
        }

        public LoginRepository(ITimeRepository timeRepository) {
            this.timeRepository = timeRepository;
        }

        public void Produce() {
            var now = this.timeRepository.Now;
            foreach (var factory in SaveData.Instance.factories) {
                if (factory.IsBought) {
                    factory.Produce(SaveData.Instance.LoginCommodity, now);
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
