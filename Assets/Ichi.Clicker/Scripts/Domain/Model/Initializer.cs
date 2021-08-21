using System.Collections;
using System.Collections.Generic;

namespace Ichi.Clicker
{
    public static class Initializer
    {
        private const int MaxRank = 20;
        private static Factory.ICalculator calculator = new FactoryCalculator();

        public static void Initialize(out Wallet wallet, out List<Factory> factories) {
            var factory = new Factory(calculator) {
                Rank = 1,
            };
            wallet = new Wallet(factory.Cost);
            factories = new List<Factory>();
            Load(factories);
        }

        public static void Load(List<Factory> factories) {
            for (var rank = 1; rank <= MaxRank; ++rank) {
                var factory = new Factory(calculator) {
                    Rank = rank,
                    Category = (int)FactoryCategory.Auto,
                };
                var find = factories.Find(t => t.EqualsFactory(factory));
                if (find != null) {
                    find.Calculator = calculator;
                } else {
                    factories.Add(factory);
                }
            }
        }
    }
}
