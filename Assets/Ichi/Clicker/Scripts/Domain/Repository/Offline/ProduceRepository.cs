using System.Collections;
using System.Collections.Generic;
using System;

namespace Ichi.Clicker.Offline
{
    public class ProduceRepository : IProduceRepository
    {
        public static readonly TimeSpan Interval = TimeSpan.FromSeconds(1);
        public static readonly TimeSpan Limit = TimeSpan.FromHours(12);
        private int cheatBonus = 1;

        public void ClickProduce() {
            foreach (var factory in SaveData.Instance.ClickFactories) {
                if (factory.IsBought) {
                    SaveData.Instance.Coin.Store(factory.Power * this.cheatBonus);
                }
            }
        }

        public void TimeProduce() {
            var now = Common.Time.Now;
            foreach (var factory in SaveData.Instance.AutoFactories) {
                if (factory.IsBought) {
                    TimeProducer.Produce(SaveData.Instance.Coin, factory.Power * this.cheatBonus, now, ref factory.producedAt);
                }
            }
        }

        public void CheatMode(bool enable) {
            this.cheatBonus = enable ? 100 : 1;
        }

        //TODO ProduceとProductが紛らわしい
    }
}
