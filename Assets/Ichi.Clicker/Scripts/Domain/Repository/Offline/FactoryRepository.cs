using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Ichi.Clicker
{
    public class FactoryRepository : IFactoryRepository
    {
        public IEnumerable<Factory> Factories { get => SaveData.Instance.Factories; }
        public IEnumerable<Factory> ClickFactories { get => SaveData.Instance.ClickFactories; }
        public IEnumerable<Factory> AutoFactories { get => SaveData.Instance.AutoFactories; }

        public void LevelUp(Factory factory) {
            factory.LevelUp(SaveData.Instance.Coin, Common.Time.Now);
            SaveData.Instance.Save();
        }

        public void Produce(Factory factory) {
            if (factory.Category != (int)FactoryCategory.Click) {
                throw new System.Exception("Invalid factory.");
            }
            factory.Produce(SaveData.Instance.Product);
        }

        public void TimeProduce(Factory factory) {
            if (factory.Category != (int)FactoryCategory.Auto) {
                throw new System.Exception("Invalid factory.");
            }
            factory.TimeProduce(SaveData.Instance.Product, Common.Time.Now);
        }
    }
}
