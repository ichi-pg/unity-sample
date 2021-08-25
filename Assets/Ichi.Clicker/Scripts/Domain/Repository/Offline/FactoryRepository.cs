using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Ichi.Clicker
{
    public class FactoryRepository : IFactoryRepository
    {
        public IEnumerable<IFactory> Factories { get => SaveData.Instance.factories; }
        public IEnumerable<IFactory> ClickFactories { get => SaveData.Instance.ClickFactories; }
        public IEnumerable<IFactory> AutoFactories { get => SaveData.Instance.AutoFactories; }

        public void LevelUp(IFactory factory) {
            (factory as Factory).LevelUp(SaveData.Instance.Coin, Common.Time.Now);
            SaveData.Instance.Save();
        }

        public void Produce(IFactory factory) {
            //TODO ボーナス
            (factory as Factory).Produce(SaveData.Instance.Coin, Common.Time.Now, 1);
        }
    }
}
