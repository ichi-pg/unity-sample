using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Numerics;

namespace Ichi.Clicker
{
    public static class Initializer
    {
        public static void Initialize(List<Clicker> clickers) {
            for (var rank = 1; rank <= 10; ++rank) {
                var clicker = clickers.FirstOrDefault(clicker => clicker.rank == rank);
                if (clicker == null) {
                    clicker = new Clicker() {
                        rank = rank,
                    };
                    clickers.Add(clicker);
                }
                clicker.Power = new BigIntegerStatus(new PowerCalculator());
                clicker.Cost = new BigIntegerStatus(new CostCalculator());
                clicker.Calculate();
            }
        }

        public static void Initialize(List<Factory> factories) {
            for (var rank = 1; rank <= 10; ++rank) {
                var factory = factories.FirstOrDefault(factory => factory.rank == rank);
                if (factory == null) {
                    factory = new Factory() {
                        rank = rank,
                        rarity = 1,
                    };
                    factories.Add(factory);
                }
                factory.Power = new BigIntegerStatus(new PowerCalculator());
                factory.Cost = new BigIntegerStatus(new CostCalculator());
                factory.Calculate();
            }
        }

        public static void Initialize(List<Item> items) {
            foreach (ItemCategory category in Enum.GetValues(typeof(ItemCategory))) {
                var item = items.FirstOrDefault(item => item.category == category);
                if (item == null) {
                    item = new Item() {
                        category = category,
                    };
                    items.Add(item);
                }
            }
        }

        public static void Initialize(List<Episode> episodes, List<Factory> factories) {
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
