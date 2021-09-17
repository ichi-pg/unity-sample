using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System;
using UniRx;

namespace Ichi.Clicker.Offline
{
    public class ClickerRepository : IProduceRepository
    {
        public IEnumerable<IGadget> Gadgets { get => this.saveDataRepository.SaveData.clickers; }
        private int cheatBonus = 1;
        private ISaveDataRepository saveDataRepository;
        private Subject<BigInteger> onProduce = new Subject<BigInteger>();
        public IObservable<BigInteger> OnProduce { get => this.onProduce; }

        public ClickerRepository(ISaveDataRepository saveDataRepository) {
            this.saveDataRepository = saveDataRepository;
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
            var power = this.saveDataRepository.SaveData.clickers.Produce(enemy, this.cheatBonus);
            this.onProduce.OnNext(power);
        }

        public void CheatMode(bool enable) {
            this.cheatBonus = enable ? 100 : 1;
        }
    }
}
