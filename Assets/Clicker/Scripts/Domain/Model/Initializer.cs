using System.Collections;
using System.Collections.Generic;

namespace Clicker
{
    public static class Initializer
    {
        public static void Initialize(out Wallet wallet, out List<Factory> factories) {
            factories = new List<Factory>();
            wallet = new Wallet(new Factory(1, false).BuyCost);
        }
    }
}
