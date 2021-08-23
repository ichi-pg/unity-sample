using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace Ichi.Clicker
{
    [System.Serializable]
    public class Item : Factory.IItem
    {
        public enum Categories
        {
            Coin,
            Product,
        }

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

        public bool Add(BigInteger quantity) {
            if (quantity < 0) {
                return false;
            }
            this.Quantity += quantity;
            return true;
        }

        public void Sell(Factory.IItem item) {
            if (this == item) {
                throw new System.Exception("Invalid item.");
            }
            if (!item.Add(this.Quantity)) {
                throw new System.Exception("Failed add item.");
            }
            this.Quantity = 0;
        }
    }
}
