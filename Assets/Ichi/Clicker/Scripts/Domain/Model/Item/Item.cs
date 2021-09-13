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
        public ItemCategory category;
        public BigInteger Quantity { get => this.quantity; }
        public event Action AlterHandler;

        public void Consume(BigInteger i) {
            if (i < 0) {
                throw new Exception("Invalid consume.");
            }
            if (this.quantity < i) {
                throw new Exception("Invalid consume.");
            }
            this.quantity -= i;
            this.AlterHandler?.Invoke();
        }

        public void Store(BigInteger i) {
            if (i < 0) {
                throw new Exception("Invalid store.");
            }
            this.quantity += i;
            this.AlterHandler?.Invoke();
        }

        public void Sell(IStore store, int bonus = 1) {
            if (this == store) {
                throw new Exception("Invalid sell.");
            }
            store.Store(this.quantity * bonus);
            this.quantity = 0;
            this.AlterHandler?.Invoke();
        }
    }
}
