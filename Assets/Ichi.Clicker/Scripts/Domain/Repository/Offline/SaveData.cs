using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Ichi.Clicker
{
    [Serializable]
    public class SaveData
    {
        private static SaveData instance = null;
        public static SaveData Instance {
            get {
                if (instance == null) {
                    if (Ichi.Common.JsonSaveData.Exist<SaveData>()) {
                        instance = Ichi.Common.JsonSaveData.Load<SaveData>();
                        //TODO クラウドセーブ
                    } else {
                        instance = new SaveData() {
                            factories = new List<Factory>(),
                            items = new List<Item>(),
                            NextFeverAt = Common.Time.Now,
                        };
                    }
                    Initializer.Initialize(
                        instance.factories,
                        instance.items
                    );
                    instance.ClickFactories = instance.factories.Where(factory => factory.category == (int)FactoryCategory.Click);
                    instance.AutoFactories = instance.factories.Where(factory => factory.category == (int)FactoryCategory.Auto);
                    instance.Coin = instance.items.FirstOrDefault(item => item.category == (int)ItemCategory.Coin);
                    instance.Product = instance.items.FirstOrDefault(item => item.category == (int)ItemCategory.Product);
                }
                return instance;
            }
        }

        public List<Factory> factories;
        public List<Item> items;
        public long nextFeverTicks;
        public Item Coin { get; private set; }
        public Item Product { get; private set; }
        public IEnumerable<Factory> ClickFactories { get; private set; }
        public IEnumerable<Factory> AutoFactories { get; private set; }

        public DateTime NextFeverAt {
            get => new DateTime(this.nextFeverTicks);
            set => this.nextFeverTicks = value.Ticks;
        }

        private SaveData() {
        }

        public void Save() {
            Ichi.Common.JsonSaveData.Save<SaveData>(this);
        }
    }
}
