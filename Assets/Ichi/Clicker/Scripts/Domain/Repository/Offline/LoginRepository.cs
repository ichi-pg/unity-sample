using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System;

namespace Ichi.Clicker.Offline
{
    public class LoginRepository : ILoginRepository
    {
        public BigInteger Quanity { get => SaveData.Instance.LoginProduct.Quantity; }
        public float Percentage { get => 0; }//TODO

        public void Produce() {
            foreach (var factory in SaveData.Instance.AutoFactories) {
                if (factory.IsBought) {
                    factory.Produce(SaveData.Instance.LoginProduct, Common.Time.Now);
                }
            }
        }

        public void Collect(bool bonus) {
            SaveData.Instance.LoginProduct.Sell(SaveData.Instance.Coin, bonus ? 2 : 1);
        }
    }
}
