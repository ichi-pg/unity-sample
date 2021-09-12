using System.Collections;
using System.Collections.Generic;
using System;

namespace Ichi.Clicker.Offline
{
    public class FactoryRepository : IFactoryRepository
    {
        public IEnumerable<IFactory> Factories { get => SaveData.Instance.factories; }
        public event Action AlterHandler;
        private int cheatBonus = 1;
        private ITimeRepository timeRepository;

        public FactoryRepository(ITimeRepository timeRepository) {
            this.timeRepository = timeRepository;
        }

        public void LevelUp(IFactory factory) {
            //TODO 好感度を消費
            (factory as Factory).LevelUp(SaveData.Instance.Coin, this.timeRepository.Now);
            if (CalculatorUtility.IsInflation(factory.Level)) {
                SaveData.Instance.Save();
            }
            this.AlterHandler?.Invoke();
        }

        public void Produce() {
            var now = this.timeRepository.Now;
            foreach (var factory in SaveData.Instance.factories) {
                if (factory.IsBought) {
                    factory.Produce(SaveData.Instance.Coin, now, this.cheatBonus);
                }
            }
        }

        public void CheatMode(bool enable) {
            this.cheatBonus = enable ? 100 : 1;
        }
    }
}
