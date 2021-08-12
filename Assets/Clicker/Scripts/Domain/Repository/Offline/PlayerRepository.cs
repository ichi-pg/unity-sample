using System.Collections;
using System.Collections.Generic;

namespace Clicker
{
    public class PlayerRepository : IPlayerRepository
    {
        public Player Get() {
            return SaveData.Instance.Player;
        }
    }
}
