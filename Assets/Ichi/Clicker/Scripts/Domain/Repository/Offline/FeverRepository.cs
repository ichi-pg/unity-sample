using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Ichi.Clicker.Offline
{
    public class FeverRepository : IFeverRepository
    {
        public TimeSpan Duration { get => TimeSpan.FromSeconds(30); }
        public TimeSpan Interval { get => TimeSpan.FromMilliseconds(100); }
        private int cheatBonus = 1;
        private DateTime finishAt = DateTime.MinValue;
        private DateTime lastAt = DateTime.MinValue;
        public event Action AlterHandler;

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
                if (SaveData.Instance.NextFeverAt < Common.Time.Now) {
                    return TimeSpan.Zero;
                }
                return SaveData.Instance.NextFeverAt - Common.Time.Now;
            }
        }

        public TimeSpan RemainDuration {
            get {
                if (this.finishAt < Common.Time.Now) {
                    return TimeSpan.Zero;
                }
                return this.finishAt - Common.Time.Now;
            }
        }

        public void Produce() {
            var now = Common.Time.Now;
            //TODO
            // if (now - this.lastAt < this.Interval) {
            //     throw new Exception("Invalid interval.");
            // }
            // this.lastAt = now;
            if (this.finishAt < now) {
                if (now < SaveData.Instance.NextFeverAt) {
                    throw new Exception("Invalid cool time.");
                }
                this.finishAt = now + this.Duration;
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
        }

        public void CoolDown() {
            SaveData.Instance.NextFeverAt = Common.Time.Now;
            SaveData.Instance.Save();
            this.AlterHandler?.Invoke();
        }

        public void CheatMode(bool enable) {
            this.cheatBonus = enable ? 100 : 1;
        }
    }
}
