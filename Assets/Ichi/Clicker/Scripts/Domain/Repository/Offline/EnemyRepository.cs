using System.Collections;
using System.Collections.Generic;
using System;
using UniRx;

namespace Ichi.Clicker.Offline
{
    public class EnemyRepository : IEnemyRepository
    {
        public IEnemy Enemy { get => this.saveDataRepository.SaveData.enemy; }
        private ISaveDataRepository saveDataRepository;
        private ITimeRepository timeRepository;
        private Subject<IEnemy> onEncount = new Subject<IEnemy>();
        public IObservable<IEnemy> OnEncount { get => this.onEncount; }

        public EnemyRepository(ISaveDataRepository saveDataRepository, ITimeRepository timeRepository) {
            this.saveDataRepository = saveDataRepository;
            this.timeRepository = timeRepository;
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
                if (factory.IsLock) {
                    factory.level = 1;
                    factory.producedAt = this.timeRepository.Now;
                }
                factory.Calculate();
                break;
            }
            enemy.level++;
            enemy.rank = 11 - (int)Math.Sqrt(UnityEngine.Random.Range(1, 101));
            enemy.damage = 0;
            enemy.Calculate();
            this.saveDataRepository.Save();
            this.onEncount.OnNext(enemy);
            //TODO 少なくとも今と別の敵をエンカウントさせる
            //TODO やはり討伐失敗も入れないと単調（制限時間->ターン数）
            //TODO ドロップもランダムにする？
            //TODO 料理もドロップにする？
            //TODO レベル調整入れないとあっという間にコンテンツ消化する
        }
    }
}
