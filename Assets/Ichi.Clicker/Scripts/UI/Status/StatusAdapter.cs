using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Linq;

namespace Ichi.Clicker
{
    public class StatusAdapter
    {
        public string CoinText { get => Dependency.LocalizationText.ToString("Status.Coin", this); }
        public string PowerText { get => Dependency.LocalizationText.ToString("Status.Power", this); }
        public string Coin { get => Ichi.Common.BigIntegerText.ToString(Dependency.WalletRepository.Get().Coin); }
        public string Power {
            get {
                BigInteger power;
                foreach (var factory in Dependency.FactoryRepository.List()) {
                    power += factory.Power;
                }
                return Ichi.Common.BigIntegerText.ToString(power);
            }
        }
    }
}