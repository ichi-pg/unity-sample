using System.Collections;
using System.Collections.Generic;

namespace Clicker
{
    public class Factory
    {
        public int Level { get; private set; } = 1;
        public int Rank { get; private set; } = 1;//TODO マスターから
        public int Power { get => this.Level * this.Rank * this.Rank; }
        public int LevelUpCost { get => this.Level * this.Level * this.Rank * 10; }
        public int BuyCost { get => this.Rank * this.Rank * 10; }

        //TODO 単純に Factory = 女の子 でいいんじゃない（カフェ、農園、メイド、基地、冒険者）？
        //TODO 正攻法だと精霊、衣装、道具、商品、土地、施設
        //TODO Factory = Merge のパターン
        //TODO 放置で増える
        //TODO HPあって死ぬ、ランダム性と選択、何日生存
        //TODO ネクロのやつは生産の間に敵を挟んでるのがえらい
        //TODO ネクロのやつはランクがハクスラになってるのがえらい
        //TODO ネクロのやつはデッキ枠で選択が生まれるのがえらい

        public void LevelUp() {
            this.Level++;
        }
    }
}
