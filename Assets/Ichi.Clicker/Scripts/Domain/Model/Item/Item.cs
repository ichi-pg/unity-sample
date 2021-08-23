using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace Ichi.Clicker
{
    [System.Serializable]
    public class Item : IStore, IConsume, ISell
    {
        public Ichi.Common.BigNumber Quantity;
        public int Category;

        public bool Consume(BigInteger quantity) {
            if (quantity < 0) {
                return false;
            }
            if (this.Quantity < quantity) {
                return false;
            }
            this.Quantity -= quantity;
            return true;
        }

        public bool Store(BigInteger quantity) {
            if (quantity < 0) {
                return false;
            }
            this.Quantity += quantity;
            return true;
        }

        public bool Sell(IStore store) {
            if (this == store) {
                return false;
            }
            if (!store.Store(this.Quantity)) {
                return false;
            }
            this.Quantity = 0;
            return true;
        }
    }
}
