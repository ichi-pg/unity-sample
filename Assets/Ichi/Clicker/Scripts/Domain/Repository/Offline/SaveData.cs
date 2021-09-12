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
                    instance = Common.JsonSaveData.Exist<SaveData>() ? Common.JsonSaveData.Load<SaveData>() : new SaveData();
                    instance.Initialize(DateTime.Now);
                    //TODO ITimeRepository, with SaveRepository?
                }
                return instance;
            }
        }

        //TODO TimeKeeperとLevelUpperに分解できない？
        public List<Clicker> clickers;
        public List<Factory> factories;
        public List<Item> items;
        public List<Episode> episodes;
        public Enemy enemy;
        public Common.TicksTime nextFeverAt;
        public Common.TicksTime nextFeverAdsAt;
        public Item Coin { get; private set; }
        public Item Commodity { get; private set; }
        public Item LoginCommodity { get; private set; }

        public void Save() {
            Common.JsonSaveData.Save<SaveData>(this);
            //TODO クラウドセーブ
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

        public void Initialize(DateTime now) {
            this.clickers = this.clickers ?? new List<Clicker>();
            this.factories = this.factories ?? new List<Factory>();
            this.items = this.items ?? new List<Item>();
            this.episodes = this.episodes ?? new List<Episode>();
            this.nextFeverAt = Common.Time.Max(this.nextFeverAt, now);
            this.nextFeverAdsAt = Common.Time.Max(this.nextFeverAdsAt, now);
            Initializer.Initialize(
                this.clickers,
                this.factories,
                this.items,
                this.episodes,
                this.enemy
            );
            this.Coin = this.items.FirstOrDefault(item => item.category == (int)ItemCategory.Coin);
            this.Commodity = this.items.FirstOrDefault(item => item.category == (int)ItemCategory.Commodity);
            this.LoginCommodity = this.items.FirstOrDefault(item => item.category == (int)ItemCategory.LoginCommodity);
        }
    }
}
