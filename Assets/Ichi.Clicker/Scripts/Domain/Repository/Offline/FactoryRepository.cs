using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Ichi.Clicker
{
    public class FactoryRepository : IFactoryRepository
    {
        public IEnumerable<IFactory> Factories { get => SaveData.Instance.factories; }
        public IEnumerable<IFactory> ClickFactories { get => SaveData.Instance.ClickFactories; }
        public IEnumerable<IFactory> AutoFactories { get => SaveData.Instance.AutoFactories; }
        public DateTime NextFeverAt { get => SaveData.Instance.NextFeverAt; }
        public TimeSpan FeverSpan { get => TimeSpan.FromSeconds(30); }
        public TimeSpan FeverInterval { get => TimeSpan.FromMilliseconds(100); }
        private int cheatBonus = 1;

        public void LevelUp(IFactory factory) {
            (factory as Factory).LevelUp(SaveData.Instance.Coin, Common.Time.Now);
            SaveData.Instance.Save();
        }

        public void Produce(IFactory factory) {
            (factory as Factory).Produce(SaveData.Instance.Coin, Common.Time.Now, this.cheatBonus);
        }

        public void FeverProduce() {
            var now = Common.Time.Now;
            foreach (var factory in SaveData.Instance.ClickFactories) {
                if (factory.IsBought) {
                    factory.Produce(SaveData.Instance.Coin, now, factory.FeverRate * this.cheatBonus);
                }
            }
            SaveData.Instance.NextFeverAt = now + TimeSpan.FromMinutes(30);
            //TODO 広告でフィーバー回復
        }

        public void CheatMode(bool enable) {
            this.cheatBonus = enable ? 100 : 1;
        }
    }
}
