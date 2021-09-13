using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Linq;
using System;

namespace Ichi.Clicker.Offline
{
    public class LoginRepository : ILoginRepository
    {
        public IItem Item { get => this.saveDataRepository.SaveData.Login; }
        private ITimeRepository timeRepository;
        private ISaveDataRepository saveDataRepository;

        public float QuantityRate {
            get {
                var power = this.saveDataRepository.SaveData.factories.Sum(factory => factory.Power);
                var count = Factory.Limit.Ticks / Factory.Interval.Ticks;
                var rate = this.saveDataRepository.SaveData.Login.Quantity * 100 / (power * count);
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

        public bool Produce() {
            var now = this.timeRepository.Now;
            foreach (var factory in this.saveDataRepository.SaveData.factories) {
                if (factory.IsBought) {
                    factory.Produce(this.saveDataRepository.SaveData.Login, now);
                }
            }
            this.saveDataRepository.Save();
            return this.saveDataRepository.SaveData.Login.Quantity > 0;
        }

        public void Collect(bool bonus) {
            this.saveDataRepository.SaveData.Login.Sell(this.saveDataRepository.SaveData.Coin, bonus ? 2 : 1);
            this.saveDataRepository.Save();
        }
    }
}
