using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System;
using UniRx;

namespace Ichi.Clicker.Offline
{
    public class FactoryRepository : IProduceRepository
    {
        private int cheatBonus = 1;
        private ITimeRepository timeRepository;
        private ISaveDataRepository saveDataRepository;
        private Subject<BigInteger> onProduce = new Subject<BigInteger>();
        public IObservable<BigInteger> OnProduce { get => this.onProduce; }

        public FactoryRepository(ITimeRepository timeRepository, ISaveDataRepository saveDataRepository) {
            this.timeRepository = timeRepository;
            this.saveDataRepository = saveDataRepository;
        }

        public void Produce() {
            var now = this.timeRepository.Now;
            BigInteger power;
            foreach (var factory in this.saveDataRepository.SaveData.factories) {
                if (factory.IsBought) {
                    power += factory.Produce(this.saveDataRepository.SaveData.Coin, now, this.cheatBonus);
                }
            }
            this.onProduce.OnNext(power);
        }

        public void CheatMode(bool enable) {
            this.cheatBonus = enable ? 100 : 1;
        }
    }
}
