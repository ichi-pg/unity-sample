using System.Collections;
using System.Collections.Generic;

namespace Ichi.Rouge
{
    public static class DIContainer
    {
        public static ICardRepository CardRepository { get; private set; } = new CardRepository();
    }
}
