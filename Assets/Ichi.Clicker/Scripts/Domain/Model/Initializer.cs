using System.Collections;
using System.Collections.Generic;

namespace Ichi.Clicker
{
    public static class Initializer
    {
        private const int MaxRank = 20;
        private static Factory.ICalculator autoCalculator = new FactoryCalculator.Auto();
        private static Factory.ICalculator clickCalculator = new FactoryCalculator.Click();

        public static void Initialize(out Wallet wallet, out List<Factory> factories) {
            wallet = new Wallet();
            factories = new List<Factory>() {
                new Factory(clickCalculator),
            };
            Load(factories);
        }

        public static void Load(List<Factory> factories) {
            for (var rank = 1; rank <= MaxRank; ++rank) {
                var factory = new Factory(autoCalculator) {
                    Rank = rank,
                    Category = (int)FactoryCategory.Auto,
                };
                var find = factories.Find(t => t.EqualsFactory(factory));
                if (find != null) {
                    find.Calculator = autoCalculator;
                } else {
                    factories.Add(factory);
                }
            }
        }
    }
}
