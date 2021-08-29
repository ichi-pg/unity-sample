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
        public bool IsAdsCoolTime { get => Common.Time.Now < SaveData.Instance.NextFeverAdsAt; }
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

        public void Produce() {
            var now = Common.Time.Now;
            if (this.finishAt < now) {
                if (now < SaveData.Instance.NextFeverAt) {
                    throw new Exception("Invalid cool time.");
                }
                this.finishAt = now + TimeSpan.FromSeconds(30);
                SaveData.Instance.NextFeverAt = now + TimeSpan.FromMinutes(30);
                SaveData.Instance.Save();
                this.AlterHandler?.Invoke();
            }
            foreach (var factory in SaveData.Instance.ClickFactories) {
                if (factory.IsBought) {
                    factory.Produce(SaveData.Instance.Coin, now, this.Rate * this.cheatBonus);
                }
            }
            //TODO 時間生産とフィーバー生産のバランス調整（クリックは最終的にいらない子）
            //TODO インターバルを超えたらエラー
        }

        public void CoolDown() {
            var now = Common.Time.Now;
            SaveData.Instance.NextFeverAt = now;
            SaveData.Instance.NextFeverAdsAt = now + TimeSpan.FromMinutes(30);
            SaveData.Instance.Save();
            this.AlterHandler?.Invoke();
            //TODO クールタイムないかフィーバー中ならエラー
        }

        public void CheatMode(bool enable) {
            this.cheatBonus = enable ? 100 : 1;
        }
    }
}
