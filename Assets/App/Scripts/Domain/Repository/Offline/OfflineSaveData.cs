using System.Collections;
using System.Collections.Generic;

public class OfflineSaveData
{
    public static OfflineSaveData Instance { get; private set; } = new OfflineSaveData();
    public List<Card> UnlockedCards { get; private set; } = new List<Card>() {
        new Card(),
        new Card(),
        new Card(),
        new Card(),
        new Card(),
    };
}
