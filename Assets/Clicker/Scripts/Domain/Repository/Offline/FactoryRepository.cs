using System.Collections;
using System.Collections.Generic;

namespace Clicker
{
    public class FactoryRepository : IFactoryRepository
    {
        public List<Factory> ListUnlocked() {
            return SaveData.Instance.Factories;
        }
        public List<Factory> ListLocked() {
            return new List<Factory>();//TODO
        }

        public void LevelUp(Factory factory) {
            SaveData.Instance.Player.ConsumCoin(factory.LevelUpCost);
            factory.LevelUp();
            SaveData.Instance.Save();
        }

        public void Produce(Factory factory) {
            SaveData.Instance.Player.AddCoin(factory.Power);
            SaveData.Instance.Save();
        }

        public void Buy(Factory factory) {
            SaveData.Instance.Player.ConsumCoin(factory.BuyCost);
            SaveData.Instance.Factories.Add(factory);
            SaveData.Instance.Save();
        }
    }
}
