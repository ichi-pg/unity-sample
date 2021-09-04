using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Ichi.Clicker
{
    public static class Initializer
    {
        public static void Initialize(List<Factory> factories, List<Item> items, List<Episode> episodes) {
            Initialize(factories, FactoryCategory.Click, 1, 1, 1);
            Initialize(factories, FactoryCategory.Auto, 2, 20, 0);
            Initialize(items, ItemCategory.Coin, 0);
            Initialize(items, ItemCategory.Commodity, 0);
            Initialize(items, ItemCategory.LoginCommodity, 0);
            Initialize(episodes, factories);
        }

        private static void Initialize(List<Factory> factories, FactoryCategory category, int rank, int maxRank, int level) {
            ICost premise = null;
            for (; rank <= maxRank; ++rank) {
                var factory = factories.FirstOrDefault(factory => factory.category == (int)category && factory.rank == rank);
                if (factory == null) {
                    factory = new Factory() {
                        category = (int)category,
                        rank = rank,
                        level = level,
                    };
                    factories.Add(factory);
                }
                factory.Power = new BigIntegerStatus(new PowerCalculator());
                factory.Cost = new BigIntegerStatus(new CostCalculator());
                factory.Locker = new CostLocker(factory, premise);
                factory.Calculate();
                premise = factory;
            }
        }

        private static void Initialize(List<Item> items, ItemCategory category, int quantity) {
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
