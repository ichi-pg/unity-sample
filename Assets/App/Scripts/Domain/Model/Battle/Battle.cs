using System.Collections;
using System.Collections.Generic;

public class Battle
{
    public enum Side {
        Player,
        Enemy,
    }

    public Dictionary<Side, Team> Teams { get; private set; }
}
