using System.Collections;
using System.Collections.Generic;

namespace Ichi.Rouge
{
    public class Repositories
    {
        public static Repositories Instance { get; private set; } = new Repositories();
        public ICardRepository CardRepository { get; private set; } = new CardRepository();

        private Repositories() {
        }
    }
}
