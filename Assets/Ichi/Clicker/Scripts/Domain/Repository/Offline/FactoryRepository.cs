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

        public void LevelUp(IFactory factory) {
            (factory as Factory).LevelUp(SaveData.Instance.Coin, Common.Time.Now);
            if (StatusUtility.IsInflation(factory.Level)) {
                SaveData.Instance.Save();
            }
            this.AlterHandler?.Invoke();
        }
    }
}
