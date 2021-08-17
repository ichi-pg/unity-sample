using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Clicker
{
    public static class Initializer
    {
        public static void Initialize(out Wallet wallet, out List<Factory> factories) {
            wallet = new Wallet(new Factory(new FactoryCalculator(), 1).Cost);
            factories = new List<Factory>();
            Load(factories);
        }

        public static void Load(List<Factory> factories) {
            var calculator = new FactoryCalculator();
            for (var i = 1; i <= 20; ++i) {
                var factory = new Factory(calculator, i);
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
