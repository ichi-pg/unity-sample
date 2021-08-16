using System.Collections;
using System.Collections.Generic;

namespace Clicker
{
    public class Repositories
    {
        public static Repositories Instance { get; private set; } = new Repositories();
        public IFactoryRepository FactoryRepository { get; private set; } = new FactoryRepository();
        public IWalletRepository WalletRepository { get; private set; } = new WalletRepository();
        public ISaveRepository SaveRepository { get; private set; } = new SaveRepository();

        private Repositories() {
        }
    }
}
