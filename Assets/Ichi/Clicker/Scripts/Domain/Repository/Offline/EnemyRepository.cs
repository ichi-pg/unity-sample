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
        private Subject<IEnemy> onWin = new Subject<IEnemy>();
        public IObservable<IEnemy> OnWin { get => this.onWin; }

        public EnemyRepository(ISaveDataRepository saveDataRepository, ITimeRepository timeRepository) {
            this.saveDataRepository = saveDataRepository;
            this.timeRepository = timeRepository;
        }

        public void Win() {
            var saveData = this.saveDataRepository.SaveData;
            var enemy = saveData.enemy;
            if (enemy.IsAlive) {
                throw new Exception("Invalid alive.");
            }
            //勝利
            this.onWin.OnNext(enemy);
            saveData.EXP.Store(enemy.HP);
            //ドロップ
            var factory = saveData.factories.FirstOrDefault(factory => factory.rank == enemy.rank);
            var k = factory.rarity + 1;
            if (UnityEngine.Random.Range(0, k * k * 10) == 0) {
                factory.RarityUp(this.timeRepository.Now);
                this.onDrop.OnNext(factory);
            }
        }

        public void Encount() {
            var saveData = this.saveDataRepository.SaveData;
            if (saveData.enemy.IsAlive) {
                throw new Exception("Invalid alive.");
            }
            //エンカウント
            //TODO レベル上昇ロジック
            var enemy = new Enemy(11 - (int)Math.Sqrt(UnityEngine.Random.Range(1, 101)));
            saveData.enemy = enemy;
            this.onEncount.OnNext(enemy);
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
