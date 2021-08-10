using System.Collections;
using System.Collections.Generic;

namespace Rouge
{
    public class OfflineCardRepository : ICardRepository
    {
        public List<Card> GetUnlockedCards() {
            return OfflineSaveData.Instance.UnlockedCards;
        }
    }
}
