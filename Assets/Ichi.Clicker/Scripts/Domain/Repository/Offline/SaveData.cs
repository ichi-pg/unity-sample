using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Ichi.Clicker
{
    [System.Serializable]
    public class SaveData
    {
        private static SaveData instance = null;
        public static SaveData Instance {
            get {
                if (instance == null) {
                    if (Ichi.Common.JsonSaveData.Exist<SaveData>()) {
                        instance = Ichi.Common.JsonSaveData.Load<SaveData>();
                    } else {
                        instance = new SaveData() {
                            Factories = new List<Factory>(),
                            Items = new List<Item>(),
                        };
                    }
                    Initializer.Initialize(
                        instance.Factories,
                        instance.Items
                    );
                    instance.ClickFactories = instance.Factories.Where(factory => factory.Category == (int)FactoryCategory.Click);
                    instance.AutoFactories = instance.Factories.Where(factory => factory.Category == (int)FactoryCategory.Auto);
                    instance.Coin = instance.Items.FirstOrDefault(item => item.Category == (int)ItemCategory.Coin);
                    instance.Product = instance.Items.FirstOrDefault(item => item.Category == (int)ItemCategory.Product);
                }
                return instance;
            }
        }

        public List<Factory> Factories;
        public List<Item> Items;
        public Item Coin { get; private set; }
        public Item Product { get; private set; }
        public IEnumerable<Factory> ClickFactories { get; private set; }
        public IEnumerable<Factory> AutoFactories { get; private set; }

        private SaveData() {
        }

        public void Save() {
            Ichi.Common.JsonSaveData.Save<SaveData>(this);
        }
    }
}
