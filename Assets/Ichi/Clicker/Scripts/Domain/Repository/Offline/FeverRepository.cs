using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace Ichi.Clicker.Offline
{
    public class FeverRepository : IFeverRepository
    {
        public bool IsFever { get => Common.Time.Now < this.finishAt; }
        public bool IsCoolTime { get => this.CoolTime > TimeSpan.Zero; }
        public bool IsAdsCoolTime { get => this.AdsCoolTime > TimeSpan.Zero; }
        public event Action AlterHandler;
        private DateTime finishAt = DateTime.MinValue;
        private int cheatBonus = 1;

        public int Rate {
            get {
                //全ての施設の性能は等価 -> オートの総生産 = クリックの施設数倍
                //1日4回ログインで2回ずつフィーバー -> 300s / 0.1s * 8回/日 * n = 86400回/日
                return SaveData.Instance.factories.Count(factory => factory.IsBought) * 3;
            }
        }

        public TimeSpan CoolTime {
            get {
                var coolTime = SaveData.Instance.NextFeverAt - Common.Time.Now;
                if (coolTime < TimeSpan.Zero) {
                    coolTime = TimeSpan.Zero;
                }
                return coolTime;
            }
        }

        public TimeSpan AdsCoolTime {
            get {
                var coolTime = SaveData.Instance.NextFeverAdsAt - Common.Time.Now;
                if (coolTime < TimeSpan.Zero) {
                    coolTime = TimeSpan.Zero;
                }
                return coolTime;
            }
        }

        public TimeSpan TimeLeft {
            get {
                var timeLeft = this.finishAt - Common.Time.Now;
                if (timeLeft < TimeSpan.Zero) {
                    timeLeft = TimeSpan.Zero;
                }
                return timeLeft;
            }
        }

        public void Fever(CancellationToken token) {
            if (this.IsFever) {
                throw new Exception("Invalid fever.");
            }
            if (this.IsCoolTime) {
                throw new Exception("Invalid cool time.");
            }
            var now = Common.Time.Now;
            this.finishAt = now + TimeSpan.FromSeconds(300);
            SaveData.Instance.NextFeverAt = now + TimeSpan.FromMinutes(30);
            this.AlterHandler?.Invoke();
            this.Produce(token).Forget();
            //TODO 理想プレイフィール = クリック楽しい、オート施設楽ちん、増える楽しい -> 段々キツくなる -> ランクアップ強い -> 段々キツくなる -> フィーバー強い -> ...
            //TODO これに対して必要な調整 = フィーバーのロック機能が必要, 序盤からフィーバー強すぎ長すぎ, ランクアップのカタルシスがない, 序盤のプレイに手応えを感じない（ぬるすぎ？メリハリがない？）, 全体的にレベルアップ早すぎ
            //TODO やっぱりレベルアップとランクアップだけだと寂しいのはある。フィーバー強化したりするSkillを追加する。
        }

        private async UniTask Produce(CancellationToken token) {
            while (this.IsFever)
            {
                var now = Common.Time.Now;
                foreach (var factory in SaveData.Instance.ClickFactories) {
                    if (factory.IsBought) {
                        factory.Produce(SaveData.Instance.Coin, now, this.Rate * this.cheatBonus);
                    }
                }
                await UniTask.Delay(TimeSpan.FromMilliseconds(100), cancellationToken: token);
            }
            SaveData.Instance.Save();
            this.AlterHandler?.Invoke();
        }

        public void CoolDown() {
            if (this.IsFever) {
                throw new Exception("Invalid fever.");
            }
            if (!this.IsCoolTime) {
                throw new Exception("Invalid cool time.");
            }
            if (this.IsAdsCoolTime) {
                throw new Exception("Invalid ads cool time.");
            }
            var now = Common.Time.Now;
            SaveData.Instance.NextFeverAt = now;
            SaveData.Instance.NextFeverAdsAt = now + TimeSpan.FromMinutes(15);
            SaveData.Instance.Save();
            this.AlterHandler?.Invoke();
        }

        public void CheatMode(bool enable) {
            this.cheatBonus = enable ? 100 : 1;
        }
    }
}
