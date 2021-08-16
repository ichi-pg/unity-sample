using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace Clicker
{
    public class StatusAdapter
    {
        public string Coin { get => "Coin"+Common.NumericTextUtility.Omit(Repositories.Instance.WalletRepository.Get().Coin); }//TODO
        public string Power {
            get {
                BigInteger power;
                foreach (var factory in Repositories.Instance.FactoryRepository.List()) {
                    power += factory.Power;
                }
                return "TotalPower"+Common.NumericTextUtility.Omit(power);//TODO
            }
        }
    }
}
