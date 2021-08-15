using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace Clicker
{
    public class Wallet
    {
        public BigInteger Coin { get; private set; }

        public Wallet(BigInteger coin) {
            this.Coin = coin;
        }

        public void ConsumCoin(BigInteger coin) {
            if (this.Coin < coin) {
                throw new System.Exception("コインが足りません");//TODO
            }
            this.Coin -= coin;
        }

        public void AddCoin(BigInteger coin) {
            this.Coin += coin;
        }
    }
}
