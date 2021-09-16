using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System;
using UniRx;

namespace Ichi.Clicker.Offline
{
    public class ClickerRepository : IGadgetRepository
    {
        public IEnumerable<IGadget> Factories { get => this.saveDataRepository.SaveData.clickers; }
        private int cheatBonus = 1;
        private ISaveDataRepository saveDataRepository;
        private IEnemyRepository enemyRepository;
        private Subject<BigInteger> onProduce = new Subject<BigInteger>();
        public IObservable<BigInteger> OnProduce { get => this.onProduce; }

        public ClickerRepository(ISaveDataRepository saveDataRepository, IEnemyRepository enemyRepository) {
            this.saveDataRepository = saveDataRepository;
            this.enemyRepository = enemyRepository;
        }

        public bool CanLevelUp(IGadget clicker) {
            return this.saveDataRepository.SaveData.Coin.Quantity >= clicker.Cost;
        }

        public void LevelUp(IGadget clicker) {
            (clicker as Clicker).LevelUp(this.saveDataRepository.SaveData.Coin);
            this.saveDataRepository.Save();
        }

        public void Produce() {
            var enemy = this.saveDataRepository.SaveData.enemy;
            if (!enemy.IsAlive) {
                throw new Exception("Invalid alive.");
            }
            BigInteger sumPower;
            foreach (var clicker in this.saveDataRepository.SaveData.clickers) {
                //TODO 弱点など
                var power = clicker.Power * this.cheatBonus;
                if (enemy.IsAlive) {
                    enemy.Store(power);
                }
                sumPower += power;
            }
            if (!enemy.IsAlive) {
                this.enemyRepository.Win();
            }
            this.onProduce.OnNext(sumPower);
        }

        public void CheatMode(bool enable) {
            this.cheatBonus = enable ? 100 : 1;
        }
    }
}
