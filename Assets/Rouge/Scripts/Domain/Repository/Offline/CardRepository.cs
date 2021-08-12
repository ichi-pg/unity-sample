using System.Collections;
using System.Collections.Generic;

namespace Rouge
{
    public class CardRepository : ICardRepository
    {
        public List<Card> ListUnlocked() {
            return SaveData.Instance.UnlockedCards;
        }
    }
}
