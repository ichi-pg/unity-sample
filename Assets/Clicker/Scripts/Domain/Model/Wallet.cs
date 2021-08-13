using System.Collections;
using System.Collections.Generic;

namespace Clicker
{
    public class Wallet
    {
        public int Coin { get; private set; }
        public string CoinText { get => "コイン"+Common.NumericTextUtility.Omit(this.Coin); }//TODO

        public Wallet(int coin) {
            this.Coin = coin;
        }

        public void ConsumCoin(int coin) {
            if (this.Coin < coin) {
                throw new System.Exception("コインが足りません");//TODO
            }
            this.Coin -= coin;
        }

        public void AddCoin(int coin) {
            this.Coin += coin;
        }
    }
}
