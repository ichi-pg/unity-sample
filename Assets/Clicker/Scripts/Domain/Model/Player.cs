using System.Collections;
using System.Collections.Generic;

namespace Clicker
{
    public class Player
    {
        public int Coin { get; private set; }

        public void ConsumCoin(int coin) {
            if (this.Coin < coin) {
                throw new System.Exception("コインが足りません");//TODO ローカライズ
            }
            this.Coin -= coin;
        }

        public void AddCoin(int coin) {
            this.Coin += coin;
        }

        public static void Initialize(out Player player, out List<Factory> factories) {
            factories = new List<Factory>();
            player = new Player();
            player.Coin = new Factory(1).BuyCost;
        }
    }
}
