using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System;
using UniRx;

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
        public Item Coin { get; private set; }
        public Item Commodity { get; private set; }
        public Item Login { get; private set; }
        public Item EXP { get; private set; }

        public void PreSave() {
            this.factories.ForEach(factory => factory.PreSave());
            this.items.ForEach(item => item.PreSave());
            this.enemy.PreSave();
            this.nextFeverAt.PreSave();
            this.nextFeverAdsAt.PreSave();
        }

        public void PostLoad() {
            this.clickers.ForEach(clicker => clicker.PostLoad());
            this.factories.ForEach(factory => factory.PostLoad());
            this.items.ForEach(item => item.PostLoad());
            this.enemy.PostLoad();
            this.nextFeverAt.PostLoad();
            this.nextFeverAdsAt.PostLoad();
        }

        public void Initialize(DateTime now) {
            this.InitializeFever(now);
            this.InitializeEnemy();
            this.InitializeClickers();
            this.InitializeFactories();
            this.InitializeItems();
            this.InitializeEpisodes();
        }

        private void InitializeFever(DateTime now) {
            this.nextFeverAt = Common.Time.Max(this.nextFeverAt, now);
            this.nextFeverAdsAt = Common.Time.Max(this.nextFeverAdsAt, now);
        }

        private void InitializeEnemy() {
            this.enemy = this.enemy ?? new Enemy(1);
        }

        private void InitializeClickers() {
            this.clickers = this.clickers ?? new List<Clicker>();
            for (var rank = 1; rank <= 10; ++rank) {
                if (this.clickers.FirstOrDefault(clicker => clicker.rank == rank) == null) {
                    this.clickers.Add(new Clicker(rank));
                }
            }
        }

        private void InitializeFactories() {
            this.factories = this.factories ?? new List<Factory>();
            for (var rank = 1; rank <= 10; ++rank) {
                if (this.factories.FirstOrDefault(factory => factory.rank == rank) == null) {
                    this.factories.Add(new Factory(rank));
                }
            }
        }

        private void InitializeItems() {
            this.items = this.items ?? new List<Item>();
            foreach (ItemCategory category in Enum.GetValues(typeof(ItemCategory))) {
                if (this.items.FirstOrDefault(item => item.category == category) == null) {
                    this.items.Add(new Item(category));
                }
            }
            this.Coin = this.items.FirstOrDefault(item => item.category == ItemCategory.Coin);
            this.Commodity = this.items.FirstOrDefault(item => item.category == ItemCategory.Commodity);
            this.Login = this.items.FirstOrDefault(item => item.category == ItemCategory.Login);
            this.EXP = this.items.FirstOrDefault(item => item.category == ItemCategory.EXP);
        }

        private void InitializeEpisodes() {
            this.episodes = this.episodes ?? new List<Episode>();
            foreach (var factory in this.factories) {
                for (var level = 100; level <= 500; level += 100) {
                    var episode = this.episodes.FirstOrDefault(episode => episode.rank == factory.Rank && episode.level == level);
                    if (episode == null) {
                        episode = new Episode() {
                            rank = factory.Rank,
                            level = level,
                        };
                        this.episodes.Add(episode);
                    }
                    episode.Locker = new LevelLocker(factory, level);
                    episode.Novels = new List<Novel>() {
                        new Novel() {
                            Text = "aaaa",
                        },
                    };
                    //NOTE シナリオマスターデータ
                }
            }
        }
    }
}
