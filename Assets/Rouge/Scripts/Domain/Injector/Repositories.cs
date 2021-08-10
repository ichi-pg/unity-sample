using System.Collections;
using System.Collections.Generic;

namespace Rouge
{
    public class Repositories
    {
        public static Repositories Instance { get; private set; } = new Repositories();
        public IUserDataRepository UserDataRepository { get; private set; } = new OfflineUserDataRepository();

        private Repositories() {
        }
    }
}
