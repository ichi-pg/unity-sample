using System.Collections;
using System.Collections.Generic;

namespace Clicker
{
    public class PlayerRepository : IPlayerRepository
    {
        public Wallet Get() {
            return SaveData.Instance.Wallet;
        }
    }
}
