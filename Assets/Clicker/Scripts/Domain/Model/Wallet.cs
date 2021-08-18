using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace Clicker
{
    [System.Serializable]
    public class Wallet : Factory.IResource
    {
        public Common.BigNumber Coin;

        public Wallet(BigInteger coin) {
            this.Coin = coin;
        }

        public bool Consum(BigInteger coin) {
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
