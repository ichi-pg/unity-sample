using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Ichi.Clicker
{
    [Serializable]
    public class SaveData : Common.IPreSave, Common.IPostLoad
    {
        public List<Clicker> clickers;
        public List<Factory> factories;
        public List<Item> items;
        public List<Episode> episodes;
        public Enemy enemy;
        public Common.TicksTime nextFeverAt;
        public Common.TicksTime nextFeverAdsAt;
        public Item coin;
        public Item commodity;
        public Item login;
        public Item exp;

        public void PreSave() {
            foreach (var factory in this.factories) {
                factory.producedAt.PreSave();
            }
            foreach (var item in this.items) {
                item.quantity.PreSave();
            }
            this.enemy.damage.PreSave();
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
            this.enemy.damage.PostLoad();
            this.nextFeverAt.PostLoad();
            this.nextFeverAdsAt.PostLoad();
        }

        public void Initialize(DateTime now) {
            this.clickers = this.clickers ?? new List<Clicker>();
            this.factories = this.factories ?? new List<Factory>();
            this.items = this.items ?? new List<Item>();
            this.episodes = this.episodes ?? new List<Episode>();
            this.enemy = this.enemy ?? new Enemy() { rank = 1 };
            this.enemy.HP = new BigIntegerStatus(new HPCalculator());
            this.enemy.Calculate();
            this.coin = this.coin ?? new Item();
            this.commodity = this.commodity ?? new Item();
            this.login = this.login ?? new Item();
            this.exp = this.exp ?? new Item();
            this.nextFeverAt = Common.Time.Max(this.nextFeverAt, now);
            this.nextFeverAdsAt = Common.Time.Max(this.nextFeverAdsAt, now);
            Initializer.Initialize(this.clickers);
            Initializer.Initialize(this.factories);
            Initializer.Initialize(this.episodes, this.factories);
        }
    }
}
