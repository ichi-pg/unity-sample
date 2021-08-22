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
            factory.LevelUp(SaveData.Instance.Items.First(), Common.Time.Now);
            SaveData.Instance.Save();
        }

        public void Produce(Factory factory) {
            if (factory.Category != (int)Factory.Categories.Click) {
                throw new System.Exception("Can not produce not click factory.");
            }
            //TODO
            factory.Produce(SaveData.Instance.Items.First());
        }

        public void Collect(Factory factory) {
            if (factory.Category != (int)Factory.Categories.Auto) {
                throw new System.Exception("Can not collect not auto factory.");
            }
            factory.Collect(SaveData.Instance.Items.First(), Common.Time.Now);
        }
    }
}
