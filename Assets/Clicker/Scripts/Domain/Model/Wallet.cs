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

        public void Consum(BigInteger coin) {
            if (this.Coin < coin) {
                throw new System.Exception("コインが足りません");//TODO
            }
            this.Coin -= coin;
        }

        public void Add(BigInteger coin) {
            this.Coin += coin;
        }
    }
}
