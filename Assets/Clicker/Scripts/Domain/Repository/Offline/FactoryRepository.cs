using System.Collections;
using System.Collections.Generic;

namespace Clicker
{
    public class FactoryRepository : IFactoryRepository
    {
        public IEnumerable<Factory> List() {
            return SaveData.Instance.Factories;
        }

        public Factory GetBuyable() {
            return Factory.GetBuyable(SaveData.Instance.Factories);
        }

        public void LevelUp(Factory factory) {
            //TODO 未購入ならエラー
            factory.LevelUp(SaveData.Instance.Wallet);
            SaveData.Instance.Save();
        }

        public void Produce(Factory factory) {
            //TODO 未購入ならエラー
            SaveData.Instance.Wallet.AddCoin(factory.Power);
            SaveData.Instance.Save();
        }

        public void Buy(Factory factory) {
            factory.Buy(
                SaveData.Instance.Factories,
                SaveData.Instance.Wallet
            );
            SaveData.Instance.Save();
        }

        //TODO この速度でSaveするのやりすぎでは。
    }
}
