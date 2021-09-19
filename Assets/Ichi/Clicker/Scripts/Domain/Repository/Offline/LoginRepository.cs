using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Linq;
using System;

namespace Ichi.Clicker.Offline
{
    public class LoginRepository : ILoginRepository
    {
        private ITimeRepository timeRepository;
        private ISaveDataRepository saveDataRepository;

        public float Rate {
            get {
                var power = this.saveDataRepository.SaveData.factories.Sum(factory => factory.Power);
                var count = Factory.Limit.Ticks / Factory.Interval.Ticks;
                return Common.Math.Divide(this.saveDataRepository.SaveData.Login.Quantity, power * count);
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
                    factory.Produce(this.saveDataRepository.SaveData.Login, now, 1);
                }
            }
            if (this.Rate >= 0.1f) {
                this.saveDataRepository.Save();
                return true;
            }
            this.Collect(false);
            return false;
        }

        public void Collect(bool bonus) {
            this.saveDataRepository.SaveData.Login.Sell(this.saveDataRepository.SaveData.Coin, bonus ? 2 : 1);
            this.saveDataRepository.Save();
        }
    }
}
