using System.Collections;
using System.Collections.Generic;

namespace Ichi.Rouge
{
    public class CardRepository : ICardRepository
    {
        public IEnumerable<Card> ListUnlocked() {
            return SaveData.Instance.UnlockedCards;
        }
    }
}
