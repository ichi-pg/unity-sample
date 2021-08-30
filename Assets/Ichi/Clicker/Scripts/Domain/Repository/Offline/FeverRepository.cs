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
                //施設が多くなると相対的にフィーバーの性能が下がるので補正（ランクアップの動機にもなる）
                var count = SaveData.Instance.factories.Count(factory => factory.IsBought);
                //だんだんレベルアップがキツくなるのでフィーバーを乗算して補う
                //TODO 階段 : シームレスで指数をなくすなら等倍
                return count * count;
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
            this.finishAt = now + TimeSpan.FromSeconds(30);
            SaveData.Instance.NextFeverAt = now + TimeSpan.FromMinutes(30);
            SaveData.Instance.Save();
            this.Produce(token).Forget();
            this.AlterHandler?.Invoke();
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
            this.AlterHandler?.Invoke();
            //TODO 時間生産とフィーバー生産のバランス調整 => power/0.1s * 30s * n回/d : power/s * s/d = 1 : 1（前提としてpowerは同値になるrate調整）
            //TODO フィーバー中にアプリ落ちたらかわいそう
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
            SaveData.Instance.NextFeverAdsAt = now + TimeSpan.FromMinutes(30);
            SaveData.Instance.Save();
            this.AlterHandler?.Invoke();
        }

        public void CheatMode(bool enable) {
            this.cheatBonus = enable ? 100 : 1;
        }
    }
}
