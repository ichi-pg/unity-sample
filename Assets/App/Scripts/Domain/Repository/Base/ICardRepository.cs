using System.Collections;
using System.Collections.Generic;

public interface ICardRepository
{
    List<Card> GetUnlockedCards();
}
