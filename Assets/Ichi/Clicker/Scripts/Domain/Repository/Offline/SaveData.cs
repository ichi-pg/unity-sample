using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Ichi.Clicker.Offline
{
    [Serializable]
    public class SaveData
    {
        private static SaveData instance = null;
        public static SaveData Instance {
            get {
                if (instance == null) {
                    var now = Common.Time.Now;
                    if (Common.JsonSaveData.Exist<SaveData>()) {
                        instance = Common.JsonSaveData.Load<SaveData>();
                        //TODO クラウドセーブ
                    } else {
                        instance = new SaveData() {
                            factories = new List<Factory>(),
                            items = new List<Item>(),
                            NextFeverAt = now,
                            NextFeverAdsAt = now,
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
                    instance.LoginProduct = instance.items.FirstOrDefault(item => item.category == (int)ItemCategory.LoginProduct);
                }
                return instance;
            }
        }

        public List<Factory> factories;
        public List<Item> items;
        public long nextFeverTicks;
        public long nextFeverAdsTicks;
        public Item Coin { get; private set; }
        public Item Product { get; private set; }
        public Item LoginProduct { get; private set; }
        public IEnumerable<Factory> ClickFactories { get; private set; }
        public IEnumerable<Factory> AutoFactories { get; private set; }

        public DateTime NextFeverAt {
            get => new DateTime(this.nextFeverTicks);
            set => this.nextFeverTicks = value.Ticks;
        }

        public DateTime NextFeverAdsAt {
            get => new DateTime(this.nextFeverAdsTicks);
            set => this.nextFeverAdsTicks = value.Ticks;
        }

        private SaveData() {
        }

        public void Save() {
            Common.JsonSaveData.Save<SaveData>(this);
        }
    }
}
