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
        private readonly static TimeSpan Duration = TimeSpan.FromSeconds(300);

        public bool IsFever { get => Common.Time.Now < this.finishAt; }
        public bool IsCoolTime { get => this.CoolTime > TimeSpan.Zero; }
        public bool IsAdsCoolTime { get => this.AdsCoolTime > TimeSpan.Zero; }
        public TimeSpan CoolTime { get => Common.Time.Max(SaveData.Instance.nextFeverAt - Common.Time.Now, TimeSpan.Zero); }
        public TimeSpan AdsCoolTime { get => Common.Time.Max(SaveData.Instance.nextFeverAdsAt - Common.Time.Now, TimeSpan.Zero); }
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

        public float DurationRate {
            get {
                var timeLeft = Common.Time.Max(this.finishAt - Common.Time.Now, TimeSpan.Zero);
                return (float)timeLeft.Ticks / Duration.Ticks;
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
            this.finishAt = now + Duration;
            SaveData.Instance.nextFeverAt = now + TimeSpan.FromMinutes(30);
            this.AlterHandler?.Invoke();
            this.Produce(token).Forget();
        }

        private async UniTask Produce(CancellationToken token) {
            while (this.IsFever)
            {
                foreach (var factory in SaveData.Instance.ClickFactories) {
                    if (factory.IsBought) {
                        SaveData.Instance.Coin.Store(factory.Power * this.Rate * this.cheatBonus);
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
            SaveData.Instance.nextFeverAt = now;
            SaveData.Instance.nextFeverAdsAt = now + TimeSpan.FromMinutes(15);
            SaveData.Instance.Save();
            this.AlterHandler?.Invoke();
        }

        public void CheatMode(bool enable) {
            this.cheatBonus = enable ? 100 : 1;
        }

        //TODO 単純にFeverモデルに
        //TODO レートはSkillモデルに
    }
}
