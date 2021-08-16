using System.Collections;
using System.Collections.Generic;

namespace Clicker
{
    [System.Serializable]
    public class Wallet : Factory.IResource
    {
        public Common.BigInteger Coin;

        public Wallet(Common.BigInteger coin) {
            this.Coin = coin;
        }

        public void Consum(Common.BigInteger coin) {
            if (this.Coin < coin) {
                throw new System.Exception("コインが足りません");//TODO
            }
            this.Coin -= coin;
        }

        public void Add(Common.BigInteger coin) {
            this.Coin += coin;
        }
    }
}
