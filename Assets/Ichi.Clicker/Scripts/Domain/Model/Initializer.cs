using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Ichi.Clicker
{
    public static class Initializer
    {
        public static void Initialize(List<Factory> factories, List<Item> items) {
            Initialize(factories, new ClickFactory(), (int)Factory.Categories.Click, 1, 1, 0);
            Initialize(factories, new AutoFactory(), (int)Factory.Categories.Auto, 20, 0, Common.Time.Now);
            Initialize(items, (int)Item.Categories.Coin, 0);
            Initialize(items, (int)Item.Categories.Product, 0);
        }

        private static void Initialize(List<Factory> factories, Factory.ICalculator calculator, int category, int maxRank, int level, long now) {
            for (var rank = 1; rank <= maxRank; ++rank) {
                var factory = factories.FirstOrDefault(factory => factory.Category == category && factory.Rank == rank);
                if (factory == null) {
                    factories.Add(new Factory(calculator) {
                        Category = category,
                        Rank = rank,
                        Level = level,
                        CollectedAt = level > 0 ? now : 0,
                    });
                } else {
                    factory.Calculator = calculator;
                }
            }
        }

        private static void Initialize(List<Item> items, int category, int quantity) {
            var item = items.FirstOrDefault(item => item.Category == category);
            if (item == null) {
                items.Add(new Item() {
                    Category = category,
                    Quantity = new Common.BigNumber(quantity),
                });
            }
        }
    }
}
