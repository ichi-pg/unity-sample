using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Ichi.Clicker
{
    public static class Initializer
    {
        public static void Initialize(List<Clicker> clickers, List<Factory> factories, List<Item> items, List<Episode> episodes) {
            Initialize(clickers);
            Initialize(factories);
            Initialize(items, ItemCategory.Coin, clickers.FirstOrDefault().Cost);
            Initialize(items, ItemCategory.Commodity);
            Initialize(items, ItemCategory.LoginCommodity);
            Initialize(episodes, factories);
        }

        private static void Initialize(List<Clicker> clickers) {
            for (var rank = 1; rank <= 10; ++rank) {
                var clicker = clickers.FirstOrDefault(clicker => clicker.rank == rank);
                if (clicker == null) {
                    clicker = new Clicker() {
                        rank = rank,
                        rarity = 1,
                    };
                    clickers.Add(clicker);
                }
                clicker.Power = new BigIntegerStatus(new PowerCalculator());
                clicker.Cost = new BigIntegerStatus(new CostCalculator());
                clicker.Calculate();
            }
        }

        private static void Initialize(List<Factory> factories) {
            for (var rank = 1; rank <= 10; ++rank) {
                var factory = factories.FirstOrDefault(factory => factory.rank == rank);
                if (factory == null) {
                    factory = new Factory() {
                        rank = rank,
                        rarity = 1,
                        isLock = true,
                    };
                    factories.Add(factory);
                }
                factory.Power = new BigIntegerStatus(new PowerCalculator());
                factory.Cost = new BigIntegerStatus(new CostCalculator());
                factory.Calculate();
            }
        }

        private static void Initialize(List<Item> items, ItemCategory category, int quantity = 0) {
            var item = items.FirstOrDefault(item => item.category == (int)category);
            if (item == null) {
                items.Add(new Item() {
                    category = (int)category,
                    quantity = quantity,
                });
            }
        }

        private static void Initialize(List<Episode> episodes, List<Factory> factories) {
            foreach (var factory in factories) {
                for (var level = 100; level <= 500; level += 100) {
                    var episode = episodes.FirstOrDefault(episode => episode.rank == factory.Rank && episode.level == level);
                    if (episode == null) {
                        episode = new Episode() {
                            rank = factory.Rank,
                            level = level,
                        };
                        episodes.Add(episode);
                    }
                    episode.Locker = new LevelLocker(factory, level);
                    episode.Sentences = new List<Sentence>() {
                        new Sentence() {
                            Text = "aaaa",
                        },
                    };
                    //TODO シナリオマスターデータ
                }
            }
        }
    }
}
