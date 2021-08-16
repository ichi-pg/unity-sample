using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Clicker
{
    [System.Serializable]
    public class Factory
    {
        public interface IResource {
            void Consum(BigInteger coin);
            void Add(BigInteger coin);
        }

        public int Level = 1;
        public int Rank;
        public int Rarity = 1;//TODO
        public BigInteger Power { get => new BigInteger(this.Level) * this.Rank * this.Rank * 10; }//TODO
        public BigInteger LevelUpCost { get => new BigInteger(this.Level) * this.Level * this.BuyCost; }//TODO
        public BigInteger BuyCost { get => new BigInteger(this.Rank)  * this.Rank * 10; }//TODO
        public float AutoProduceInterval { get => 1.0f; }//TODO
        public bool IsLocked { get; private set; } = true;

        //NOTE 単純に Factory = 女の子 でいいんじゃない（カフェ、農園、メイド、基地、冒険者）？
        //NOTE 正攻法だと精霊、衣装、道具、商品、土地、施設
        //NOTE Factory = Merge のパターン
        //NOTE 施設増えすぎた時に下級施設のマージ
        //NOTE マージガチャ
        //NOTE クリッカーはすぐ飽きるが放置ゲーは飽きづらい、何故。ガチャとキャラ育成？ランダム要素。取捨選択。
        //NOTE 放置で増える
        //NOTE HPあって死ぬ、ランダム性と選択、何日生存
        //NOTE ネクロは生産の間に敵を挟んでるのがえらい
        //NOTE ネクロはランクがハクスラになってるのがえらい
        //NOTE ネクロはデッキ枠で選択が生まれるのがえらい
        //NOTE ネクロもギターも広告がうまい（通常プレイを妨げず、フィーバーorレアリティアップしたい欲で広告）
        //NOTE 高ランクの生産効率が良すぎるが、ランク解放には全体のレベル上げないといけないので良バランスかも。レベルアップ頻度に不満があるので、ランク開放と合わせてライン上げするくらいでちょうどいいかも。
        //NOTE 見ていて楽しいガワが必須（ギターは演奏とLine、ネクロはミニキャラがちょこちょこ動いて戦闘）
        //NOTE 生産力は共通で毎秒＋タップ加速＋フィーバー

        public Factory(int rank) {
            this.Rank = rank;
        }

        public Factory(int rank, int level) {
            this.Rank = rank;
            this.Level = level;
        }

        public void LevelUp(IResource resource) {
            if (this.IsLocked) {
                throw new System.Exception("未購入です");//TODO
            }
            resource.Consum(this.LevelUpCost);
            this.Level++;
        }

        public static IEnumerable<Factory> ListBuyable(IEnumerable<Factory> factories) {
            //TODO levelで開放じゃなくて単に見えてるがBuyCostが高い
            var result = new List<Factory>();
            var level = GetPlayerLevel(factories);
            var rank = GetNextRank(factories);
            if (level >= GetNextPlayerLevel(rank)) {
                result.Add(new Factory(rank));
            }
            return result;
        }

        public static int GetPlayerLevel(IEnumerable<Factory> factories) {
            return factories.Select(t => t.Level).Sum() + 1;
        }

        public static int GetNextRank(IEnumerable<Factory> factories) {
            return factories.Select(t => t.Rank).DefaultIfEmpty().Max() + 1;
        }

        public static int GetNextPlayerLevel(IEnumerable<Factory> factories) {
            return GetNextPlayerLevel(GetNextRank(factories));
        }

        public static int GetNextPlayerLevel(int rank) {
            return rank * rank * rank;
        }

        public void Buy(List<Factory> factories, IResource resource) {
            if (!this.IsLocked) {
                throw new System.Exception("購入済みです");//TODO
            }
            resource.Consum(this.BuyCost);
            factories.Add(this);
            this.IsLocked = false;
        }

        public void Produce(IResource resource) {
            if (this.IsLocked) {
                throw new System.Exception("未購入です");//TODO
            }
            resource.Add(this.Power);
        }

        public bool EqualsFactory(Factory factory) {
            return this.Rank == factory.Rank;
        }
    }
}
