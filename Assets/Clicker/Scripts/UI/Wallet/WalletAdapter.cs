using System.Collections;
using System.Collections.Generic;

namespace Clicker
{
    public class WalletAdapter
    {
        private Wallet wallet;

        public string Coin { get => "コイン"+Common.NumericTextUtility.Omit(this.wallet.Coin); }//TODO

        public WalletAdapter(Wallet wallet) {
            this.wallet = wallet;
        }
    }
}
