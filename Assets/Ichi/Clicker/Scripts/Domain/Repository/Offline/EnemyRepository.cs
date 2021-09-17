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
        private Subject<IGadget> onDrop = new Subject<IGadget>();
        public IObservable<IGadget> OnDrop { get => this.onDrop; }
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
            this.saveDataRepository.Save();
        }

        public void Encount() {
            var saveData = this.saveDataRepository.SaveData;
            if (saveData.enemy.IsAlive) {
                throw new Exception("Invalid alive.");
            }
            //エンカウント
            var enemy = new Enemy(11 - (int)Math.Sqrt(UnityEngine.Random.Range(1, 101)));
            saveData.enemy = enemy;
            this.onEncount.OnNext(enemy);
            this.saveDataRepository.Save();
            //TODO 必ず別の敵をエンカウントさせる
            //TODO 捕獲済み敵ランク+2までエンカウント、ドロップする
            //TODO 料理は敵ランクを開放しないと手が出ない階段購入額にする
            //TODO 敵レベルの成長ルールは？
            //TODO 討伐失敗入れる（ターン数=自HP+敵ATKと同義な調整の制限時間）？
            //TODO 強敵出現、挑戦、レアリティの高いドロップ？
            //TODO ドロップ->レアリティアップ挑戦（ポーションの見せ方変えただけ）？
            //TODO リズムとか長押し防御とかフリックとか、敵を倒すことにあそびを儲けても？外れる？
        }
    }
}
