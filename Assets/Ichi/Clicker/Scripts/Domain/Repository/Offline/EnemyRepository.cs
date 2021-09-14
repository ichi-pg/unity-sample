using System.Collections;
using System.Collections.Generic;
using System;

namespace Ichi.Clicker.Offline
{
    public class EnemyRepository : IEnemyRepository
    {
        public IEnemy Enemy { get => this.saveDataRepository.SaveData.enemy; }
        private ISaveDataRepository saveDataRepository;
        public event Action AlterHandler;

        public EnemyRepository(ISaveDataRepository saveDataRepository) {
            this.saveDataRepository = saveDataRepository;
        }

        public void Encount() {
            var saveData = this.saveDataRepository.SaveData;
            var enemy = saveData.enemy;
            saveData.EXP.Store(enemy.HP);
            foreach (var factory in saveData.factories) {
                if (factory.rank != enemy.rank) {
                    continue;
                }
                if (0 == UnityEngine.Random.Range(0, factory.rarity * factory.rarity * 10)) {
                    factory.rarity++;
                }
                factory.level = Math.Max(factory.level, 1);
                factory.Calculate();
                break;
            }
            enemy.level++;
            enemy.rank = 11 - (int)Math.Sqrt(UnityEngine.Random.Range(1, 101));
            enemy.damage = 0;
            enemy.Calculate();
            this.saveDataRepository.Save();
            this.AlterHandler?.Invoke();
        }
    }
}
