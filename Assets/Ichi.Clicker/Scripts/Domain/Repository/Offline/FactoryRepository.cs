using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Ichi.Clicker
{
    public class FactoryRepository : IFactoryRepository
    {
        public IEnumerable<Factory> List() {
            return SaveData.Instance.Factories;
        }

        public IEnumerable<Factory> List(Factory.Categories category, bool isLocked = false) {
            return SaveData.Instance.Factories.Where(t => t.Category == (int)category && t.IsLocked == isLocked);
        }

        public void LevelUp(Factory factory) {
            //TODO
            var coin = SaveData.Instance.Items.FirstOrDefault(t => t.Category == (int)Item.Categories.Coin);
            factory.LevelUp(coin, Common.Time.Now);
            SaveData.Instance.Save();
        }

        public void Produce(Factory factory) {
            if (factory.Category != (int)Factory.Categories.Click) {
                throw new System.Exception("Can not produce not click factory.");
            }
            //TODO
            var coin = SaveData.Instance.Items.FirstOrDefault(t => t.Category == (int)Item.Categories.Coin);
            factory.Produce(coin);
        }

        public void Collect(Factory factory) {
            if (factory.Category != (int)Factory.Categories.Auto) {
                throw new System.Exception("Can not collect not auto factory.");
            }
            //TODO
            var coin = SaveData.Instance.Items.FirstOrDefault(t => t.Category == (int)Item.Categories.Coin);
            factory.Collect(coin, Common.Time.Now);
        }
    }
}
