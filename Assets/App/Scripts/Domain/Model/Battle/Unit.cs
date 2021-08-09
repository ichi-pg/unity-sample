using System.Collections;
using System.Collections.Generic;

public class Unit
{
    public List<Relic> Relics { get; private set; }
    public int HP { get; private set; }
    public Deck Deck { get; private set; }
    public Hand Hand { get; private set; }
}
