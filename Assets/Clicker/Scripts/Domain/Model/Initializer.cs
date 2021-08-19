using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Clicker
{
    public static class Initializer
    {
        private const int MaxRank = 20;

        public static void Initialize(out Wallet wallet, out List<Factory> factories) {
            var factory = new Factory(GetCalculator(), 1);
            wallet = new Wallet(factory.Cost);
            factories = new List<Factory>();
            Load(factories);
        }

        public static void Load(List<Factory> factories) {
            var calculator = GetCalculator();
            for (var i = 1; i <= MaxRank; ++i) {
                var factory = new Factory(calculator, i);
                var find = factories.Find(t => t.EqualsFactory(factory));
                if (find != null) {
                    find.Calculator = calculator;
                } else {
                    factories.Add(factory);
                }
            }
        }

        private static Factory.ICalculator GetCalculator() {
            return new FactoryCalculator();
        }
    }
}
