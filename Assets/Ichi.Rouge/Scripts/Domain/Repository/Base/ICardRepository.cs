using System.Collections;
using System.Collections.Generic;

namespace Ichi.Rouge
{
    public interface ICardRepository
    {
        IEnumerable<Card> ListUnlocked();
    }
}
