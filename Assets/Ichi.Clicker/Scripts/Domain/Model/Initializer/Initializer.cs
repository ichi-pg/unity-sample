using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Ichi.Clicker
{
    public static class Initializer
    {
        public static void Initialize(List<Factory> factories, List<Item> items) {
            Initialize(factories, new ClickerPowerCalculator(), new ClickerCostCalculator(), new Producer(), (int)FactoryCategory.Click, 1, 1);
            Initialize(factories, new PowerCalculator(), new CostCalculator(), new TimeProducer(), (int)FactoryCategory.Auto, 20, 0);
            Initialize(items, (int)ItemCategory.Coin, 0);
            Initialize(items, (int)ItemCategory.Product, 0);
        }

        private static void Initialize(List<Factory> factories, ILevelCalculator power, ILevelCalculator cost, IProducer producer, int category, int maxRank, int level) {
            for (var rank = 1; rank <= maxRank; ++rank) {
                var factory = factories.FirstOrDefault(factory => factory.category == category && factory.rank == rank);
                if (factory == null) {
                    factory = new Factory() {
                        category = category,
                        rank = rank,
                        level = level,
                    };
                    factories.Add(factory);
                }
                factory.PowerCalculator = power;
                factory.CostCalculator = cost;
                factory.Producer = producer;
                factory.Calculate();
            }
        }

        private static void Initialize(List<Item> items, int category, int quantity) {
            var item = items.FirstOrDefault(item => item.category == category);
            if (item == null) {
                items.Add(new Item() {
                    category = category,
                    quantity = new Common.BigNumber(quantity),
                });
            }
        }
    }
}
