using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Clicker
{
    public class FactoryRepository : IFactoryRepository
    {
        public List<Factory> List() {
            return SaveData.Instance.Factories;
        }
        public Factory GetBuyable() {
            var level = SaveData.Instance.Factories.Sum(t => t.Level) + 1;
            var rank = SaveData.Instance.Factories.Max(t => t.Rank) + 1;
            if (level < rank * rank) {
                return null;
            }
            return new Factory(rank);
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
