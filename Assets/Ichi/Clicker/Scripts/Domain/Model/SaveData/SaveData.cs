using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Ichi.Clicker
{
    [Serializable]
    public class SaveData : Common.IPreSave, Common.IPostLoad
    {
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

        public void PreSave() {
            foreach (var factory in this.factories) {
                factory.producedAt.PreSave();
            }
            foreach (var item in this.items) {
                item.quantity.PreSave();
            }
            this.enemy.hp.PreSave();
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
            this.enemy.hp.PostLoad();
            this.nextFeverAt.PostLoad();
            this.nextFeverAdsAt.PostLoad();
        }

        public void Initialize(DateTime now) {
            this.clickers = this.clickers ?? new List<Clicker>();
            this.factories = this.factories ?? new List<Factory>();
            this.items = this.items ?? new List<Item>();
            this.episodes = this.episodes ?? new List<Episode>();
            this.enemy = this.enemy ?? new Enemy();
            Initializer.Initialize(this.clickers);
            Initializer.Initialize(this.factories);
            Initializer.Initialize(this.items, ItemCategory.Coin, this.clickers.FirstOrDefault().Cost);
            Initializer.Initialize(this.items, ItemCategory.Commodity);
            Initializer.Initialize(this.items, ItemCategory.LoginCommodity);
            Initializer.Initialize(this.episodes, this.factories);
            Initializer.Initialize(this.enemy);
            this.Coin = this.items.FirstOrDefault(item => item.category == (int)ItemCategory.Coin);
            this.Commodity = this.items.FirstOrDefault(item => item.category == (int)ItemCategory.Commodity);
            this.LoginCommodity = this.items.FirstOrDefault(item => item.category == (int)ItemCategory.LoginCommodity);
            this.nextFeverAt = Common.Time.Max(this.nextFeverAt, now);
            this.nextFeverAdsAt = Common.Time.Max(this.nextFeverAdsAt, now);
        }
    }
}
