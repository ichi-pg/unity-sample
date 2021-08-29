using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Ichi.Clicker.Offline
{
    public class FeverRepository : IFeverRepository
    {
        public event Action AlterHandler;
        public TimeSpan Interval { get => TimeSpan.FromMilliseconds(100); }
        public bool IsFever { get => Common.Time.Now < this.finishAt; }
        public bool IsCoolTime { get => this.CoolTime > TimeSpan.Zero; }
        public bool IsAdsCoolTime { get => this.AdsCoolTime > TimeSpan.Zero; }
        private DateTime finishAt = DateTime.MinValue;
        private int cheatBonus = 1;

        public int Rate {
            get {
                //施設が多くなると相対的にフィーバーの性能が下がるので補正（ランクアップの動機にもなる）
                var count = SaveData.Instance.ClickFactories.Count(factory => factory.IsBought);
                //だんだんレベルアップがキツくなるのでフィーバーを乗算して補う
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

        public void Fever() {
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
            this.AlterHandler?.Invoke();
        }

        public void Produce() {
            if (!this.IsFever) {
                throw new Exception("Invalid fever.");
            }
            var now = Common.Time.Now;
            foreach (var factory in SaveData.Instance.ClickFactories) {
                if (factory.IsBought) {
                    factory.Produce(SaveData.Instance.Coin, now, this.Rate * this.cheatBonus);
                }
            }
            //TODO 時間生産とフィーバー生産のバランス調整（クリックは最終的にいらない子）
            //TODO インターバルを超えたらエラー
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
