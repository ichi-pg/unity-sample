using System.Collections;
using System.Collections.Generic;
using System;

namespace Ichi.Clicker.Offline
{
    public class FactoryRepository : IFactoryRepository
    {
        public IEnumerable<IFactory> Factories { get => this.saveDataRepository.SaveData.factories; }
        private int cheatBonus = 1;
        private ITimeRepository timeRepository;
        private ISaveDataRepository saveDataRepository;

        public FactoryRepository(ITimeRepository timeRepository, ISaveDataRepository saveDataRepository) {
            this.timeRepository = timeRepository;
            this.saveDataRepository = saveDataRepository;
        }

        public bool CanLevelUp(IFactory factory) {
            return !factory.IsLock && this.saveDataRepository.SaveData.EXP.Quantity >= factory.Cost;
        }

        public void LevelUp(IFactory factory) {
            (factory as Factory).LevelUp(this.saveDataRepository.SaveData.EXP);
            this.saveDataRepository.Save();
        }

        public void Produce() {
            var now = this.timeRepository.Now;
            foreach (var factory in this.saveDataRepository.SaveData.factories) {
                if (factory.IsBought) {
                    factory.Produce(this.saveDataRepository.SaveData.Coin, now, this.cheatBonus);
                }
            }
        }

        public void CheatMode(bool enable) {
            this.cheatBonus = enable ? 100 : 1;
        }
    }
}
