using System.Collections;
using System.Collections.Generic;

public class Repositories
{
    public static Repositories Instance { get; private set; } = new Repositories();
    public ICardRepository CardRepository { get; private set; } = new OfflineCardRepository();

    private Repositories() {
    }
}
