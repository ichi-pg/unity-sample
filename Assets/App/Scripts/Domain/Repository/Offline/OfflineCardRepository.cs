using System.Collections;
using System.Collections.Generic;

public class OfflineCardRepository : ICardRepository
{
    public List<Card> GetUnlockedCards() {
        return OfflineSaveData.Instance.UnlockedCards;
    }
}
