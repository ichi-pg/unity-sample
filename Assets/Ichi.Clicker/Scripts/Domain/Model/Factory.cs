using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace Ichi.Clicker
{
    [System.Serializable]
    public class Factory
    {
        public interface IResource {
            bool Consume(BigInteger coin);
            bool Add(BigInteger coin);
        }

        public interface ICalculator {
            BigInteger Power(BigInteger level, BigInteger rank, BigInteger rarity);
            BigInteger Cost(BigInteger level, BigInteger rank, BigInteger rarity);
            BigInteger Price(BigInteger level, BigInteger rank, BigInteger rarity);
            long Interval { get; }
        }

        public int Level;
        public int Rank;
        public int Rarity;
        public int Category;
        public long CollectedAt;
        public BigInteger Power { get => this.Calculator.Power(this.Level, this.Rank, this.Rarity); }
        public BigInteger NextPower { get => this.Calculator.Power(this.Level + 1, this.Rank, this.Rarity); }
        public BigInteger Cost { get => this.Calculator.Cost(this.Level, this.Rank, this.Rarity); }
        public BigInteger CostPerformance { get => this.Cost / (this.NextPower - this.Power); }
        public BigInteger Price { get => this.Calculator.Price(this.Level, this.Rank, this.Rarity); }
        public bool IsLocked { get => this.Level <= 0; }
        public ICalculator Calculator { private get; set; }

        public Factory(ICalculator calculator) {
            this.Calculator = calculator;
        }

        public void LevelUp(IResource resource, long now) {
            if (!resource.Consume(this.Cost)) {
                throw new System.Exception("Failed consume resource.");
            }
            if (this.Level <= 0) {
                this.CollectedAt = now;
            }
            this.Level++;
        }

        public void Produce(IResource resource) {
            if (this.IsLocked) {
                throw new System.Exception("Locked factory.");
            }
            if (!resource.Add(this.Power)) {
                throw new System.Exception("Failed add resource.");
            }
        }

        public void Collect(IResource resource, long now) {
            if (this.IsLocked) {
                throw new System.Exception("Locked factory.");
            }
            if (now < this.CollectedAt) {
                throw new System.Exception("Invalid time.");
            }
            var count = (now - this.CollectedAt) / this.Calculator.Interval;
            if (!resource.Add(this.Power * count)) {
                throw new System.Exception("Failed add resource.");
            }
            this.CollectedAt = now;
        }

        public void Sell(IResource resource, List<Factory> factories) {
            if (this.IsLocked) {
                throw new System.Exception("Locked factory.");
            }
            if (!factories.Remove(this)) {
                throw new System.Exception("Invalid factories.");
            }
            if (!resource.Add(this.Price)) {
                throw new System.Exception("Failed add resource.");
            }
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
        //NOTE 見ていて楽しいガワが必須（ギターは演奏とLine、ネクロはミニキャラがちょこちょこ動いて戦闘）
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
