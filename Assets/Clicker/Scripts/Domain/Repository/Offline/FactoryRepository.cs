using System.Collections;
using System.Collections.Generic;

namespace Clicker
{
    public class FactoryRepository : IFactoryRepository
    {
        public IEnumerable<Factory> List() {
            return SaveData.Instance.Factories;
        }

        public IEnumerable<Factory> ListBuyable() {
            return Factory.ListBuyable(SaveData.Instance.Factories);
        }

        public void LevelUp(Factory factory) {
            factory.LevelUp(SaveData.Instance.Wallet);
            SaveData.Instance.Save();
        }

        public void Produce(Factory factory) {
            factory.Produce(SaveData.Instance.Wallet);
        }

        public void Buy(Factory factory) {
            factory.Buy(
                SaveData.Instance.Factories,
                SaveData.Instance.Wallet
            );
            SaveData.Instance.Save();
        }
    }
}
