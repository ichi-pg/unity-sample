using System.Collections;
using System.Collections.Generic;

namespace Clicker
{
    [System.Serializable]
    public class Wallet : Factory.IWallet
    {
        public Common.BigInteger Coin;

        public Wallet(Common.BigInteger coin) {
            this.Coin = coin;
        }

        public void ConsumCoin(Common.BigInteger coin) {
            if (this.Coin < coin) {
                throw new System.Exception("コインが足りません");//TODO
            }
            this.Coin -= coin;
        }

        public void AddCoin(Common.BigInteger coin) {
            this.Coin += coin;
        }
    }
}
