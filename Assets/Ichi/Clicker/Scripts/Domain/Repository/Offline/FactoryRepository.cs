using System.Collections;
using System.Collections.Generic;
using System;

namespace Ichi.Clicker.Offline
{
    public class FactoryRepository : IFactoryRepository
    {
        public IEnumerable<IFactory> Factories { get => SaveData.Instance.factories; }
        public IEnumerable<IFactory> ClickFactories { get => SaveData.Instance.ClickFactories; }
        public IEnumerable<IFactory> AutoFactories { get => SaveData.Instance.AutoFactories; }
        public event Action AlterHandler;
        private int cheatBonus = 1;

        public void LevelUp(IFactory factory) {
            (factory as Factory).LevelUp(SaveData.Instance.Coin, Common.Time.Now);
            SaveData.Instance.Save();
            this.AlterHandler?.Invoke();
            //TODO 現状レベルアップのみ高頻度セーブ。25レベルごとなどに落としてもいい。強制セーブと楽観セーブに分けて使う側は気にしない設計もあり。
        }

        public void Produce(IFactory factory) {
            (factory as Factory).Produce(SaveData.Instance.Coin, Common.Time.Now, this.cheatBonus);
        }

        public void CheatMode(bool enable) {
            this.cheatBonus = enable ? 100 : 1;
        }
    }
}
