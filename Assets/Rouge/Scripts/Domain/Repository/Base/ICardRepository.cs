using System.Collections;
using System.Collections.Generic;

namespace Rouge
{
    public interface ICardRepository
    {
        List<Card> GetUnlockedCards();
    }
}
