using System.Collections;
using System.Collections.Generic;

namespace Clicker
{
    public class Repositories
    {
        public static Repositories Instance { get; private set; } = new Repositories();
        public IFactoryRepository FactoryRepository { get; private set; } = new FactoryRepository();
        public IPlayerRepository PlayerRepository { get; private set; } = new PlayerRepository();

        private Repositories() {
        }
    }
}
