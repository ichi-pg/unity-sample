using System.Collections;
using System.Collections.Generic;

public class OfflineCardRepository : ICardRepository
{
    public Card GetCard() {
        return new Card("aaaa");
    }

    public List<Card> GetCards() {
        return new List<Card>() {
            new Card("1"),
            new Card("2"),
            new Card("3"),
            new Card("4"),
            new Card("5"),
        };
    }
}
