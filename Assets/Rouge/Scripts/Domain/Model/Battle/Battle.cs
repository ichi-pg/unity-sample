using System.Collections;
using System.Collections.Generic;

namespace Rouge
{
    public class Battle
    {
        public enum Side {
            Player,
            Enemy,
        }

        public Dictionary<Side, Team> Teams { get; private set; }

        //TODO 単純に Battle = Clicker でいいんじゃない？
    }
}
