using System.Collections;
using System.Collections.Generic;

namespace Rouge
{
    public class OfflineUserDataRepository : IUserDataRepository
    {
        public List<Card> GetUnlockedCards() {
            return OfflineSaveData.Instance.UnlockedCards;
        }

        public void FinishDungeon() {
        }
    }
}
