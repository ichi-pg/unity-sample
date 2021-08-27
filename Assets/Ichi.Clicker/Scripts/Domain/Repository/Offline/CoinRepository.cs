using System.Collections;
using System.Collections.Generic;

namespace Ichi.Clicker.Offline
{
    public class CoinRepository : ICoinRepository
    {
        public IItem Coin { get => SaveData.Instance.Coin; }
    }
}
