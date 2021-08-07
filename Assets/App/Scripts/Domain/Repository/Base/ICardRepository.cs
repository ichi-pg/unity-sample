using System.Collections;
using System.Collections.Generic;

public interface ICardRepository
{
    Card GetCard();
    List<Card> GetCards();
}
