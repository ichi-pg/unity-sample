using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System;
using UniRx;

namespace Ichi.Clicker
{
    [Serializable]
    public class Item : IItem, IStore, IConsume, Common.IPreSave, Common.IPostLoad
    {
        public Common.BigNumber quantity;
        public ItemCategory category;
        public BigInteger Quantity { get => this.quantity; }
        private Subject<BigInteger> onAlter;
        public IObservable<BigInteger> OnAlter { get => this.onAlter; }

        public Item(ItemCategory category) {
            this.category = category;
            this.Initialize();
        }

        public void PreSave() {
            this.quantity.PreSave();
        }

        public void PostLoad() {
            this.quantity.PostLoad();
            this.Initialize();
        }

        private void Initialize() {
            this.onAlter = new Subject<BigInteger>();
        }

        public void Consume(BigInteger i) {
            if (i < 0) {
                throw new Exception("Invalid consume.");
            }
            if (this.quantity < i) {
                throw new Exception("Invalid consume.");
            }
            this.quantity -= i;
            this.onAlter.OnNext(-i);
        }

        public void Store(BigInteger i) {
            if (i < 0) {
                throw new Exception("Invalid store.");
            }
            this.quantity += i;
            this.onAlter.OnNext(i);
        }

        public void Sell(IStore store, int bonus = 1) {
            if (this == store) {
                throw new Exception("Invalid sell.");
            }
            store.Store(this.quantity * bonus);
            this.onAlter.OnNext(-this.quantity);
            this.quantity = 0;
        }
    }
}
