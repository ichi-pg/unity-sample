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

        //TODO データと挙動分けたい
        public List<Factory> factories;
        public List<Item> items;
        public Common.TicksTime nextFeverAt;
        public Common.TicksTime nextFeverAdsAt;
        public Item Coin { get; private set; }
        public Item Product { get; private set; }
        public Item LoginProduct { get; private set; }
        public IEnumerable<Factory> ClickFactories { get; private set; }
        public IEnumerable<Factory> AutoFactories { get; private set; }

        private SaveData(DateTime now) {
            this.factories = new List<Factory>();
            this.items = new List<Item>();
            this.nextFeverAt = now;
            this.nextFeverAdsAt = now;
        }

        public void Save() {
            Common.JsonSaveData.Save<SaveData>(this);
        }

        public void PreSave() {
            foreach (var factory in this.factories) {
                factory.producedAt.PreSave();
            }
            foreach (var item in this.items) {
                item.quantity.PreSave();
            }
            this.nextFeverAt.PreSave();
            this.nextFeverAdsAt.PreSave();
        }

        public void PostLoad() {
            foreach (var factory in this.factories) {
                factory.producedAt.PostLoad();
            }
            foreach (var item in this.items) {
                item.quantity.PostLoad();
            }
            this.nextFeverAt.PostLoad();
            this.nextFeverAdsAt.PostLoad();
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
