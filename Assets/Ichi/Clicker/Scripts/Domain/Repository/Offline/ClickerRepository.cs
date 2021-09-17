using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System;
using UniRx;

namespace Ichi.Clicker.Offline
{
    public class ClickerRepository : IProduceRepository
    {
        private int cheatBonus = 1;
        private ISaveDataRepository saveDataRepository;
        private Subject<BigInteger> onProduce = new Subject<BigInteger>();
        public IObservable<BigInteger> OnProduce { get => this.onProduce; }

        public ClickerRepository(ISaveDataRepository saveDataRepository) {
            this.saveDataRepository = saveDataRepository;
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
