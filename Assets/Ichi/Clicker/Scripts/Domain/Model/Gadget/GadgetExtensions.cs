
using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace Ichi.Clicker
{
    public static class GadgetExtensions
    {
        public static BigInteger Produce(this IEnumerable<IGadget> list, IAliveStore store, int rate) {
            BigInteger res;
            foreach (var gadget in list) {
                if (gadget.IsBought) {
                    //TODO 弱点など
                    var power = gadget.Power * rate;
                    if (store.IsAlive) {
                        store.Store(power);
                    }
                    res += power;
                }
            }
            return res;
        }
    }
}
