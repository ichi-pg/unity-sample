using System.Collections;
using System.Collections.Generic;
using System;

namespace Ichi.Clicker.Offline
{
    public class ClickerRepository : IClickerRepository
    {
        public IEnumerable<IFactory> Factories { get => this.saveDataRepository.SaveData.clickers; }
        public event Action AlterHandler;
        private int cheatBonus = 1;
        private ISaveDataRepository saveDataRepository;

        public ClickerRepository(ISaveDataRepository saveDataRepository) {
            this.saveDataRepository = saveDataRepository;
        }

        public void LevelUp(IFactory clicker) {
            (clicker as Clicker).LevelUp(this.saveDataRepository.SaveData.coin);
            if (CalculatorUtility.IsInflation(clicker.Level)) {
                this.saveDataRepository.Save();
            }
            this.AlterHandler?.Invoke();
        }

        public void Produce() {
            var enemy = this.saveDataRepository.SaveData.enemy;
            foreach (var clicker in this.saveDataRepository.SaveData.clickers) {
                if (clicker.IsBought) {
                    clicker.Produce(enemy, this.cheatBonus);
                    if (!enemy.IsAlive) {
                        //TODO エンカウント
                        //TODO ドロップ
                        break;
                    }
                }
            }
        }

        public void CheatMode(bool enable) {
            this.cheatBonus = enable ? 100 : 1;
        }
    }
}
