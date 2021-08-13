using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Clicker
{
    public class Factory
    {
        public string Name { get => "Rank"+this.Rank+" Lv"+this.Level; }//TODO
        public int Level { get; private set; } = 1;
        public int Rank { get; private set; }
        public int Power { get => this.Level * this.Rank * this.Rank; }
        public int LevelUpCost { get => this.Level * this.Level * this.Rank * this.Rank * 10; }
        public int BuyCost { get => this.Rank * this.Rank * 10; }
        public float AutoProduceInterval { get; private set; } = 1.0f;//TODO

        //NOTE 単純に Factory = 女の子 でいいんじゃない（カフェ、農園、メイド、基地、冒険者）？
        //NOTE 正攻法だと精霊、衣装、道具、商品、土地、施設
        //NOTE Factory = Merge のパターン
        //NOTE 放置で増える
        //NOTE HPあって死ぬ、ランダム性と選択、何日生存
        //NOTE ネクロのやつは生産の間に敵を挟んでるのがえらい
        //NOTE ネクロのやつはランクがハクスラになってるのがえらい
        //NOTE ネクロのやつはデッキ枠で選択が生まれるのがえらい

        public Factory(int rank) {
            this.Rank = rank;
        }

        public void LevelUp(Wallet wallet) {
            wallet.ConsumCoin(this.LevelUpCost);
            this.Level++;
        }

        public static Factory GetBuyable(IEnumerable<Factory> factories) {
            var level = factories.Select(t => t.Level).Sum() + 1;
            var rank = factories.Select(t => t.Rank).DefaultIfEmpty().Max() + 1;
            if (level < rank * rank) {
                return null;
            }
            return new Factory(rank);
        }

        public void Buy(List<Factory> factories, Wallet wallet) {
            if (factories.Any(t => t.Rank == this.Rank)) {
                throw new System.Exception("購入済みです");//TODO ローカライズ
            }
            wallet.ConsumCoin(this.BuyCost);
            factories.Add(this);
        }
    }
}
