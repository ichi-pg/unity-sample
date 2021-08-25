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

        public void LevelUp(IFactory factory) {
            (factory as Factory).LevelUp(SaveData.Instance.Coin, Common.Time.Now);
            SaveData.Instance.Save();
        }

        public void Produce(IFactory factory) {
            (factory as Factory).Produce(SaveData.Instance.Coin, Common.Time.Now);
        }

        public void FeverProduce() {
            var now = Common.Time.Now;
            foreach (var factory in SaveData.Instance.ClickFactories) {
                if (!factory.IsLocked) {
                    factory.Produce(SaveData.Instance.Coin, now, factory.FeverRate);
                }
            }
            SaveData.Instance.NextFeverAt = now + TimeSpan.FromMinutes(30);//TODO 調整
            //TODO 広告でフィーバー回復
        }
    }
}
