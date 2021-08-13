using System.Collections;
using System.Collections.Generic;

namespace Clicker
{
    public class WalletRepository : IWalletRepository
    {
        public Wallet Get() {
            return SaveData.Instance.Wallet;
        }
    }
}
