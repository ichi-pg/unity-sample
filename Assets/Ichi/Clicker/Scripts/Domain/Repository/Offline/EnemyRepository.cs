using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        private Subject<IFactory> onDrop = new Subject<IFactory>();
        public IObservable<IFactory> OnDrop { get => this.onDrop; }
        private Subject<IEnemy> onDestroy = new Subject<IEnemy>();
        public IObservable<IEnemy> OnDestroy { get => this.OnDestroy; }

        public EnemyRepository(ISaveDataRepository saveDataRepository, ITimeRepository timeRepository) {
            this.saveDataRepository = saveDataRepository;
            this.timeRepository = timeRepository;
        }

        public void Encount() {
            var saveData = this.saveDataRepository.SaveData;
            var enemy = saveData.enemy;
            //撃破
            this.onDestroy.OnNext(enemy);
            saveData.EXP.Store(enemy.HP);
            //ドロップ
            var factory = saveData.factories.FirstOrDefault(factory => factory.rank == enemy.rank);
            var k = factory.rarity + 1;
            if (UnityEngine.Random.Range(0, k * k * 10) == 0) {
                factory.RarityUp(this.timeRepository.Now);
                this.onDrop.OnNext(factory);
            }
            //エンカウント
            saveData.enemy = new Enemy(11 - (int)Math.Sqrt(UnityEngine.Random.Range(1, 101)));
            this.onEncount.OnNext(saveData.enemy);
            this.saveDataRepository.Save();
            //TODO 少なくとも今と別の敵をエンカウントさせる
            //TODO やはり討伐失敗も入れないと単調（制限時間->ターン数=自HP+敵ATKと同義）
            //TODO ドロップもランダムにする？
            //TODO 料理もドロップにする？
            //TODO レベル調整入れないとあっという間にコンテンツ消化する
            //TODO シンプルにリソースをモンスターだけにして、クリック担当、オート担当、スキル担当に分ける？クリックとオートは掛け算
            //TODO 強敵出現、挑戦、レアリティの高いドロップ
            //TODO ドロップ->レアリティアップ挑戦（ポーションの見せ方変えただけ）
        }
    }
}
