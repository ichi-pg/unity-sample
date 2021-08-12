using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Clicker
{
    public class Factory
    {
        public int Level { get; private set; } = 1;
        public int Rank { get; private set; }
        public int Power { get => this.Level * this.Rank * this.Rank; }
        public int LevelUpCost { get => this.Level * this.Level * this.Rank * this.Rank * 10; }
        public int BuyCost { get => this.Rank * this.Rank * 10; }

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

        public void LevelUp() {
            this.Level++;
        }

        public static Factory GetBuyable(IEnumerable<Factory> factories) {
            var level = factories.Sum(t => t.Level) + 1;
            var rank = factories.Max(t => t.Rank) + 1;
            if (level < rank * rank) {
                return null;
            }
            return new Factory(rank);
        }
    }
}
