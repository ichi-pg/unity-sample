using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace Ichi.Clicker
{
    [System.Serializable]
    public class Factory
    {
        public int Level;
        public int Rank;
        public int Rarity;
        public int Category;
        public long ProducedAt;
        public BigInteger Power { get => this.Calculator.Power(this.Level, this.Rank, this.Rarity); }
        public BigInteger NextPower { get => this.Calculator.Power(this.Level + 1, this.Rank, this.Rarity); }
        public BigInteger Cost { get => this.Calculator.Cost(this.Level, this.Rank, this.Rarity); }
        public BigInteger CostPerformance { get => this.Cost / (this.NextPower - this.Power); }
        public BigInteger Price { get => this.Calculator.Price(this.Level, this.Rank, this.Rarity); }
        public bool IsLocked { get => this.Level <= 0; }
        public IFactoryCalculator Calculator { private get; set; }

        public Factory(IFactoryCalculator calculator) {
            this.Calculator = calculator;
        }

        public void LevelUp(IItem item, long now) {
            if (!item.Consume(this.Cost)) {
                throw new System.Exception("Failed consume item.");
            }
            if (this.Level <= 0) {
                this.ProducedAt = now;
            }
            this.Level++;
        }

        //TODO 時間生産とクリック生産どっちも持ってるの歪よな

        public void Produce(IItem item) {
            if (this.IsLocked) {
                throw new System.Exception("Locked factory.");
            }
            if (this.Calculator.Interval > 0) {
                throw new System.Exception("Invalid interval.");
            }
            if (!item.Add(this.Power)) {
                throw new System.Exception("Failed add item.");
            }
        }

        public void TimeProduce(IItem item, long now) {
            if (this.IsLocked) {
                throw new System.Exception("Locked factory.");
            }
            if (this.Calculator.Interval <= 0) {
                throw new System.Exception("Invalid interval.");
            }
            if (now < this.ProducedAt) {
                throw new System.Exception("Invalid time.");
            }
            var count = (now - this.ProducedAt) / this.Calculator.Interval;
            if (!item.Add(this.Power * count)) {
                throw new System.Exception("Failed add item.");
            }
            this.ProducedAt = now;
        }

        public void Sell(IItem item) {
            if (this.IsLocked) {
                throw new System.Exception("Locked factory.");
            }
            if (!item.Add(this.Price)) {
                throw new System.Exception("Failed add item.");
            }
            this.ProducedAt = 0;
            this.Level = 0;
        }

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
        //NOTE ギターはクリッカー＋シナリオ開放＋衣装開放の好例
        //NOTE クラクラはクリッカー＋箱庭＋タワーディフェンス
        //NOTE 高ランクの生産効率が良すぎるが、ランク解放には全体のレベル上げないといけないので良バランスかも。レベルアップ頻度に不満があるので、ランク開放と合わせてライン上げするくらいでちょうどいいかも。
        //NOTE 単純なゲーム性なので見ていて楽しいガワが必須（ギターは演奏とLine、ネクロはミニキャラがちょこちょこ動いて戦闘）
        //NOTE 単純なゲーム性なので面白いお話が必要。ノベル＋クリッカー。世界観。
        //NOTE 生産力は共通で毎秒＋タップ加速＋フィーバー
        //NOTE クリッカー＋リズムゲーム（音ゲー）のパターン
        //NOTE 借金返済が目的で、返済をするごとにレベルアップ、完済でゲームクリア
        //NOTE levelで開放じゃなくて単に見えてるがBuyCostが高い
        //NOTE 各施設レベルマックスを設ける
        //NOTE だんだん詰まってきて、新しい施設開放で枷が外れる、を繰り返すカタルシスポイント
        //NOTE 購入速度がだんだん鈍化するのがある点を超えると飽きにつながる（＝リセット？）
        //NOTE クリッカーPvPってできそうだけど。ランダム性、取捨選択を加えないと競技性がない。
        //NOTE ランク別に生産カーブを変化させる（早熟、晩熟）
        //NOTE 施設を購入だけでなく売れる（総レベルアップ費用×n）
        //NOTE コインじゃなく、モノを生産する。ビジュアル的面白さ。モノを中継してコインを得る。
        //NOTE 最初にクリックから始まり、徐々に施設が充実する。
    }
}
