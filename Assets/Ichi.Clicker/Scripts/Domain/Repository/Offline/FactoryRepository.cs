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

        public IEnumerable<Factory> List(FactoryCategory category, bool isLocked = false) {
            return SaveData.Instance.Factories.Where(t => t.Category == (int)category && t.IsLocked == isLocked);
        }

        public void LevelUp(Factory factory) {
            factory.LevelUp(SaveData.Instance.Wallet, Common.Time.Now);
            SaveData.Instance.Save();
        }

        public void Produce(Factory factory) {
            if (factory.Category != (int)FactoryCategory.Click) {
                throw new System.Exception("Can not produce not click factory.");
            }
            factory.Produce(SaveData.Instance.Wallet);
        }

        public void Collect(Factory factory) {
            if (factory.Category != (int)FactoryCategory.Auto) {
                throw new System.Exception("Can not collect not auto factory.");
            }
            factory.Collect(SaveData.Instance.Wallet, Common.Time.Now);
        }
    }
}
