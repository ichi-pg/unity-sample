using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace Ichi.Clicker
{
    [System.Serializable]
    public class Item : IItem
    {
        public Ichi.Common.BigNumber quantity;
        public int category;
        public BigInteger Quantity { get => this.quantity.Integer; }

        public bool Consume(BigInteger quantity) {
            if (quantity < 0) {
                return false;
            }
            if (this.quantity < quantity) {
                return false;
            }
            this.quantity -= quantity;
            return true;
        }

        public bool Store(BigInteger quantity) {
            if (quantity < 0) {
                return false;
            }
            this.quantity += quantity;
            return true;
        }

        public bool Sell(IStore store) {
            if (this == store) {
                return false;
            }
            if (!store.Store(this.quantity)) {
                return false;
            }
            this.quantity = 0;
            return true;
        }
    }
}
