using System.Collections;
using System.Collections.Generic;

namespace Rouge
{
    public interface ICardRepository
    {
        IEnumerable<Card> ListUnlocked();
    }
}
