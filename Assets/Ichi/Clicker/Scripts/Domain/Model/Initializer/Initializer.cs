using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Ichi.Clicker
{
    public static class Initializer
    {
        public static void Initialize(List<Factory> factories, List<Item> items) {
            Initialize(factories, FactoryCategory.Click, 1, 1, 1);
            Initialize(factories, FactoryCategory.Auto, 2, 20, 0);
            Initialize(items, ItemCategory.Coin, 0);
            Initialize(items, ItemCategory.Product, 0);
            Initialize(items, ItemCategory.LoginProduct, 0);
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
                switch (category) {
                    case FactoryCategory.Click:
                        factory.Producer = new Producer();
                        break;
                    case FactoryCategory.Auto:
                        factory.Producer = new TimeProducer(factory);
                        break;
                }
                factory.Power = new BigIntegerStatus(new PowerCalculator());
                factory.Cost = new BigIntegerStatus(new CostCalculator());
                factory.Lock = new PremiseLock(factory, premise);
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
    }
}
