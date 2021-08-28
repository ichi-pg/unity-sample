using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace Ichi.Clicker
{
    public static class FactoryUtility
    {
        public static BigInteger SumPower(IEnumerable<IFactory> factories) {
            BigInteger power;
            foreach (var factory in DIContainer.FactoryRepository.AutoFactories) {
                power += factory.Power;
            }
            return power;
        }
    }
}
