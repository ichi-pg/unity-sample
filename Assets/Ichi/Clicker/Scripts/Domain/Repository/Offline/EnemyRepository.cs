using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UniRx;
using Random = UnityEngine.Random;

namespace Ichi.Clicker.Offline
{
    public class EnemyRepository : IEnemyRepository
    {
        public IEnemy Enemy { get => this.saveDataRepository.SaveData.Enemy; }
        private ISaveDataRepository saveDataRepository;
        private ITimeRepository timeRepository;
        private Subject<IEnemy> onEncount = new Subject<IEnemy>();
        public IObservable<IEnemy> OnEncount { get => this.onEncount; }
        private Subject<IGadget> onDrop = new Subject<IGadget>();
        public IObservable<IGadget> OnDrop { get => this.onDrop; }
        private Subject<IEnemy> onWin = new Subject<IEnemy>();
        public IObservable<IEnemy> OnWin { get => this.onWin; }
        private Enemy beforeEnemy;

        public EnemyRepository(ISaveDataRepository saveDataRepository, ITimeRepository timeRepository) {
            this.saveDataRepository = saveDataRepository;
            this.timeRepository = timeRepository;
        }

        public void Win() {
            var saveData = this.saveDataRepository.SaveData;
            var enemy = saveData.Enemy;
            if (enemy == null) {
                throw new Exception("Not found enemy.");
            }
            if (enemy.IsAlive) {
                throw new Exception("Enemy is alive.");
            }
            //経験値
            saveData.EXP.Store(enemy.HP);
            //ドロップ
            var factory = saveData.factories.FirstOrDefault(factory => factory.Rank == enemy.Rank);
            var k = factory.Rarity;
            var a = Random.Range(0, k * k * 10) == 0;
            var b = factory.Rank == 1 && !factory.IsBought;
            if (a || b) {
                factory.RarityUp(this.timeRepository.Now);
                this.onDrop.OnNext(factory);
            }
            //通知とセーブ
            saveData.Enemy = null;
            this.beforeEnemy = enemy;
            this.onWin.OnNext(enemy);
            this.saveDataRepository.Save();
        }

        public void Encount() {
            var saveData = this.saveDataRepository.SaveData;
            var enemy = saveData.Enemy;
            if (enemy != null && enemy.IsAlive) {
                throw new Exception("Enemy is alive.");
            }
            //エンカウント
            var boughtFactories = saveData.factories.Where(factory => factory.IsBought);
            Enemy newEnemy;
            if (boughtFactories.Count() > 0) {
                var boughtMaxRank = boughtFactories.Select(factory => factory.Rank).Max();
                var ranks = saveData.factories
                    .Where(
                        factory => factory.Rank <= boughtMaxRank + 2 &&
                        (this.beforeEnemy == null || factory.Rank != this.beforeEnemy.Rank)
                    )
                    .Select(factory => factory.Rank);
                var maxRank = ranks.Max();
                newEnemy = new Enemy(
                    ranks.SelectMany(i => Enumerable.Repeat<int>(i, maxRank - i + 1))
                        .OrderBy(i => Guid.NewGuid())
                        .FirstOrDefault()
                );
            } else {
                //最初の敵
                newEnemy = new Enemy(1);
            }
            //通知とセーブ
            saveData.Enemy = newEnemy;
            this.beforeEnemy = null;
            this.onEncount.OnNext(newEnemy);
            this.saveDataRepository.Save();
            //NEXT 順番にレアリティ上げるんじゃなくて、確率で渡す。
            //NEXT 料理は敵ランクを開放しないと手が出ない階段購入額にする。
            //NEXT 合わせて生産コインも階段にする。
            //NEXT 合わせて敵のHPも増やす。レベル形式。
            //TODO ダンジョンを「選ぶ」要素。
            //TODO 討伐失敗入れる（ターン数=自HP+敵ATKと同義な調整の制限時間）？
            //TODO 強敵出現、挑戦、レアリティの高いドロップ？
            //TODO ドロップ->レアリティアップ挑戦（ポーションの見せ方変えただけ）？
            //TODO リズムとか長押し防御とかフリックとか、敵を倒すことにあそびを儲けても？外れる？
            //TODO Cliker=攻防HPの方が楽しいかも？明確にバトル感。
            //TODO 弱点いる？
        }
    }
}
