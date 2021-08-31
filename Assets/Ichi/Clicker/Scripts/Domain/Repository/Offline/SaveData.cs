using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Ichi.Clicker.Offline
{
    [Serializable]
    public class SaveData : Common.IPreSave, Common.IPostLoad
    {
        private static SaveData instance = null;
        public static SaveData Instance {
            get {
                if (instance == null) {
                    if (Common.JsonSaveData.Exist<SaveData>()) {
                        instance = Common.JsonSaveData.Load<SaveData>();
                        //NOTE クラウドセーブ
                    } else {
                        instance = new SaveData(Common.Time.Now);
                    }
                    instance.Initialize();
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

        private SaveData(DateTime now) {
            this.factories = new List<Factory>();
            this.items = new List<Item>();
            this.NextFeverAt = now;
            this.NextFeverAdsAt = now;
        }

        public void Save() {
            Common.JsonSaveData.Save<SaveData>(this);
        }

        public void PreSave() {
            foreach (var item in this.items) {
                item.quantity.PreSave();
            }
        }

        public void PostLoad() {
            foreach (var item in this.items) {
                item.quantity.PostLoad();
            }
        }

        public void Initialize() {
            Initializer.Initialize(
                this.factories,
                this.items
            );
            this.ClickFactories = this.factories.Where(factory => factory.category == (int)FactoryCategory.Click);
            this.AutoFactories = this.factories.Where(factory => factory.category == (int)FactoryCategory.Auto);
            this.Coin = this.items.FirstOrDefault(item => item.category == (int)ItemCategory.Coin);
            this.Product = this.items.FirstOrDefault(item => item.category == (int)ItemCategory.Product);
            this.LoginProduct = this.items.FirstOrDefault(item => item.category == (int)ItemCategory.LoginProduct);
        }
    }
}
