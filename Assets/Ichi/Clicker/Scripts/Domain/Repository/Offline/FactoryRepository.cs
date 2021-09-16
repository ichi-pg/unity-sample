using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System;
using UniRx;

namespace Ichi.Clicker.Offline
{
    public class FactoryRepository : IProduceRepository
    {
        public IEnumerable<IGadget> Factories { get => this.saveDataRepository.SaveData.factories; }
        private int cheatBonus = 1;
        private ITimeRepository timeRepository;
        private ISaveDataRepository saveDataRepository;
        private Subject<BigInteger> onProduce = new Subject<BigInteger>();
        public IObservable<BigInteger> OnProduce { get => this.onProduce; }

        public FactoryRepository(ITimeRepository timeRepository, ISaveDataRepository saveDataRepository) {
            this.timeRepository = timeRepository;
            this.saveDataRepository = saveDataRepository;
        }

        public bool CanLevelUp(IGadget factory) {
            return !factory.IsLock && this.saveDataRepository.SaveData.EXP.Quantity >= factory.Cost;
        }

        public void LevelUp(IGadget factory) {
            (factory as Factory).LevelUp(this.saveDataRepository.SaveData.EXP);
            this.saveDataRepository.Save();
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
