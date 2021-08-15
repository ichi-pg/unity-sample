using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace Clicker
{
    [System.Serializable]
    public class Wallet
    {
        public string coinString;
        private BigInteger coinInteger;
        public BigInteger Coin {
            get {
                if (this.coinInteger == 0 && this.coinString != "") {
                    this.coinInteger = BigInteger.Parse(this.coinString);
                }
                return this.coinInteger;
            }
            set {
                //TODO BigIntegerがシリアライズされないので一旦
                this.coinInteger = value;
                this.coinString = this.coinInteger.ToString();
            }
        }

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
