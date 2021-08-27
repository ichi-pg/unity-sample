using System.Collections;
using System.Collections.Generic;

namespace Ichi.Rouge
{
    public class SaveData
    {
        public static SaveData Instance { get; private set; } = new SaveData();
        public List<Card> UnlockedCards { get; private set; } = new List<Card>() {
            new Card(),
            new Card(),
            new Card(),
            new Card(),
            new Card(),
        };
    }
}
