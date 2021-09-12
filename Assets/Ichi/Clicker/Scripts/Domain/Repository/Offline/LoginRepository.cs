using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Linq;
using System;

namespace Ichi.Clicker.Offline
{
    public class LoginRepository : ILoginRepository
    {
        public BigInteger Quantity { get => this.saveDataRepository.SaveData.login.Quantity; }
        private ITimeRepository timeRepository;
        private ISaveDataRepository saveDataRepository;

        public float QuantityRate {
            get {
                var power = this.saveDataRepository.SaveData.factories.Sum(factory => factory.Power);
                var count = Factory.Limit.Ticks / Factory.Interval.Ticks;
                var rate = this.saveDataRepository.SaveData.login.Quantity * 100 / (power * count);
                if (rate > 100) {
                    return 1f;
                }
                return (float)rate / 100;
            }
        }

        public LoginRepository(ITimeRepository timeRepository, ISaveDataRepository saveDataRepository) {
            this.timeRepository = timeRepository;
            this.saveDataRepository = saveDataRepository;
        }

        public void Produce() {
            var now = this.timeRepository.Now;
            foreach (var factory in this.saveDataRepository.SaveData.factories) {
                if (factory.IsBought) {
                    factory.Produce(this.saveDataRepository.SaveData.login, now);
                }
            }
            this.saveDataRepository.Save();
        }

        public void Collect(bool bonus) {
            this.saveDataRepository.SaveData.login.Sell(this.saveDataRepository.SaveData.coin, bonus ? 2 : 1);
            this.saveDataRepository.Save();
        }
    }
}
