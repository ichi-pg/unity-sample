using System.Collections;
using System.Collections.Generic;

namespace Ichi.Clicker
{
    public static class Initializer
    {
        public static void Initialize(out Wallet wallet, out List<Factory> factories) {
            wallet = new Wallet();
            factories = new List<Factory>();
            Load(factories);
        }

        public static void Load(List<Factory> factories) {
            Load(factories, new ClickFactory(), FactoryCategory.Click, 1, 1, 0);
            Load(factories, new AutoFactory(), FactoryCategory.Auto, 20, 0, Common.Time.Now);
        }

        private static void Load(List<Factory> factories, Factory.ICalculator calculator, FactoryCategory category, int maxRank, int level, long now) {
            for (var rank = 1; rank <= maxRank; ++rank) {
                var factory = factories.Find(t => t.Category == (int)category && t.Rank == rank);
                if (factory == null) {
                    factories.Add(new Factory(calculator){
                        Category = (int)category,
                        Rank = rank,
                        Level = level,
                        CollectedAt = now,
                    });
                } else {
                    factory.Calculator = calculator;
                }
            }
        }
    }
}
