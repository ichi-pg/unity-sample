using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace Ichi.Clicker
{
    [System.Serializable]
    public class Wallet : Factory.IResource
    {
        public Ichi.Common.BigNumber Coin;

        public bool Consume(BigInteger coin) {
            if (this.Coin < coin) {
                return false;
            }
            this.Coin -= coin;
            return true;
        }

        public void Add(BigInteger coin) {
            this.Coin += coin;
        }
    }
}
