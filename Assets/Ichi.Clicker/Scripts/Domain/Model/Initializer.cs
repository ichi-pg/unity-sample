using System.Collections;
using System.Collections.Generic;

namespace Ichi.Clicker
{
    public static class Initializer
    {
        public static void Initialize(List<Factory> factories, List<Item> items) {
            Initialize(factories, new ClickFactory(), Factory.Categories.Click, 1, 1, 0);
            Initialize(factories, new AutoFactory(), Factory.Categories.Auto, 20, 0, Common.Time.Now);
            Initialize(items, Item.Categories.Coin, 0);
        }

        private static void Initialize(List<Factory> factories, Factory.ICalculator calculator, Factory.Categories category, int maxRank, int level, long now) {
            for (var rank = 1; rank <= maxRank; ++rank) {
                var factory = factories.Find(t => t.Category == (int)category && t.Rank == rank);
                if (factory == null) {
                    factories.Add(new Factory(calculator) {
                        Category = (int)category,
                        Rank = rank,
                        Level = level,
                        CollectedAt = level > 0 ? now : 0,
                    });
                } else {
                    factory.Calculator = calculator;
                }
            }
        }

        private static void Initialize(List<Item> items, Item.Categories category, int quantity) {
            var item = items.Find(t => t.Category == (int)category);
            if (item == null) {
                items.Add(new Item() {
                    Category = (int)category,
                    Quantity = new Common.BigNumber(quantity),
                });
            }
        }
    }
}
