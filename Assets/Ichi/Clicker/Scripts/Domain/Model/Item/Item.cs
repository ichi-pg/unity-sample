using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System;

namespace Ichi.Clicker
{
    [Serializable]
    public class Item : IItem, IStore, IConsume
    {
        public Common.BigNumber quantity;
        public int category;
        public BigInteger Quantity { get => this.quantity; }
        public event Action AlterHandler;

        public bool Consume(BigInteger i) {
            if (i < 0) {
                return false;
            }
            if (this.quantity < i) {
                return false;
            }
            this.quantity -= i;
            this.AlterHandler?.Invoke();
            return true;
        }

        public bool Store(BigInteger i) {
            if (i < 0) {
                return false;
            }
            this.quantity += i;
            this.AlterHandler?.Invoke();
            return true;
        }

        public bool Sell(IStore store, int bonus = 1) {
            if (this == store) {
                return false;
            }
            if (!store.Store(this.quantity * bonus)) {
                return false;
            }
            this.quantity = 0;
            this.AlterHandler?.Invoke();
            return true;
        }
    }
}
