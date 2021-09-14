using System.Collections;
using System.Collections.Generic;
using System;

namespace Ichi.Clicker.Offline
{
    public class ClickerRepository : IFactoryRepository
    {
        public IEnumerable<IFactory> Factories { get => this.saveDataRepository.SaveData.clickers; }
        private int cheatBonus = 1;
        private ISaveDataRepository saveDataRepository;
        private IEnemyRepository enemyRepository;

        public ClickerRepository(ISaveDataRepository saveDataRepository, IEnemyRepository enemyRepository) {
            this.saveDataRepository = saveDataRepository;
            this.enemyRepository = enemyRepository;
        }

        public bool CanLevelUp(IFactory clicker) {
            return this.saveDataRepository.SaveData.Coin.Quantity >= clicker.Cost;
        }

        public void LevelUp(IFactory clicker) {
            (clicker as Clicker).LevelUp(this.saveDataRepository.SaveData.Coin);
            this.saveDataRepository.Save();
        }

        public void Produce() {
            var enemy = this.saveDataRepository.SaveData.enemy;
            foreach (var clicker in this.saveDataRepository.SaveData.clickers) {
                if (clicker.IsBought && enemy.IsAlive) {
                    clicker.Produce(enemy, this.cheatBonus);
                }
                if (!enemy.IsAlive) {
                    this.enemyRepository.Encount();
                    break;
                }
            }
            //TODO まとめて通知したい
        }

        public void CheatMode(bool enable) {
            this.cheatBonus = enable ? 100 : 1;
        }
    }
}
