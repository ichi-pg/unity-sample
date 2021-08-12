using System.Collections;
using System.Collections.Generic;

namespace Rouge
{
    public class CardRepository : ICardRepository
    {
        public IEnumerable<Card> ListUnlocked() {
            return SaveData.Instance.UnlockedCards;
        }
    }
}
