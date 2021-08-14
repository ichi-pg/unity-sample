using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Clicker
{
    [System.Serializable]
    public class Factory
    {
        public int Level { get; private set; } = 1;
        public int Rank { get; private set; }
        public int Rarity { get; private set; }//TODO
        public int Power { get => this.Level * this.Rank * this.Rank; }//TODO 高ランクの方がレベル上げ効率が良すぎる。
        public int LevelUpCost { get => this.Level * this.Level * this.Rank * this.Rank * 10; }
        public int BuyCost { get => this.Rank * this.Rank * 10; }
        public float AutoProduceInterval { get => 0.1f; }//TODO
        public bool IsUnlocked { get; private set; }//TODO 保存しない。ロード時にtrue。

        //NOTE 単純に Factory = 女の子 でいいんじゃない（カフェ、農園、メイド、基地、冒険者）？
        //NOTE 正攻法だと精霊、衣装、道具、商品、土地、施設
        //NOTE Factory = Merge のパターン
        //NOTE 放置で増える
        //NOTE HPあって死ぬ、ランダム性と選択、何日生存
        //NOTE ネクロは生産の間に敵を挟んでるのがえらい
        //NOTE ネクロはランクがハクスラになってるのがえらい
        //NOTE ネクロはデッキ枠で選択が生まれるのがえらい
        //NOTE ネクロもギターも広告がうまい（通常プレイを妨げず、フィーバーorレアリティアップしたい欲で広告）

        public Factory(int rank) {
            this.Rank = rank;
        }

        public void LevelUp(Wallet wallet) {
            if (!this.IsUnlocked) {
                throw new System.Exception("未購入です");//TODO
            }
            wallet.ConsumCoin(this.LevelUpCost);
            this.Level++;
        }

        public static Factory GetBuyable(IEnumerable<Factory> factories) {
            var level = factories.Select(t => t.Level).Sum() + 1;
            var rank = factories.Select(t => t.Rank).DefaultIfEmpty().Max() + 1;
            if (level < rank * rank * rank) {
                return null;
            }
            return new Factory(rank);
        }

        public void Buy(List<Factory> factories, Wallet wallet) {
            if (this.IsUnlocked) {
                throw new System.Exception("購入済みです");//TODO
            }
            wallet.ConsumCoin(this.BuyCost);
            factories.Add(this);
            this.IsUnlocked = true;
        }

        public void Produce(Wallet wallet) {
            if (!this.IsUnlocked) {
                throw new System.Exception("未購入です");//TODO
            }
            wallet.AddCoin(this.Power);
        }
    }
}
