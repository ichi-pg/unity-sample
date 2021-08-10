using System.Collections;
using System.Collections.Generic;

namespace Rouge
{
    public interface IUserDataRepository
    {
        List<Card> GetUnlockedCards();
        void FinishDungeon();
    }
}
