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
        public Item Coin { get; private set; }
        public Item Commodity { get; private set; }
        public Item Login { get; private set; }
        public Item EXP { get; private set; }

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
            this.enemy = this.enemy ?? new Enemy() {
                level = 1,
                rank = 1,
            };
            this.enemy.HP = new BigIntegerStatus(new HPCalculator());
            this.enemy.Calculate();
        }

        private void InitializeClickers() {
            this.clickers = this.clickers ?? new List<Clicker>();
            for (var rank = 1; rank <= 10; ++rank) {
                var clicker = this.clickers.FirstOrDefault(clicker => clicker.rank == rank);
                if (clicker == null) {
                    clicker = new Clicker() {
                        rank = rank,
                    };
                    this.clickers.Add(clicker);
                }
                if (rank == 1) {
                    clicker.level = Math.Max(clicker.level, 1);
                }
                clicker.Power = new BigIntegerStatus(new PowerCalculator());
                clicker.Cost = new BigIntegerStatus(new CostCalculator());
                clicker.Calculate();
            }
        }

        private void InitializeFactories() {
            this.factories = this.factories ?? new List<Factory>();
            for (var rank = 1; rank <= 10; ++rank) {
                var factory = this.factories.FirstOrDefault(factory => factory.rank == rank);
                if (factory == null) {
                    factory = new Factory() {
                        rank = rank,
                        rarity = 1,
                    };
                    this.factories.Add(factory);
                }
                factory.Power = new BigIntegerStatus(new PowerCalculator());
                factory.Cost = new BigIntegerStatus(new CostCalculator());
                factory.Calculate();
            }
        }

        private void InitializeItems() {
            this.items = this.items ?? new List<Item>();
            foreach (ItemCategory category in Enum.GetValues(typeof(ItemCategory))) {
                var item = this.items.FirstOrDefault(item => item.category == category);
                if (item == null) {
                    item = new Item() {
                        category = category,
                    };
                    this.items.Add(item);
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
