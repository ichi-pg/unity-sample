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
            Crop,
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
    }
}
