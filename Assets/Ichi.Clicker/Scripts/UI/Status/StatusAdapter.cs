using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Linq;

namespace Ichi.Clicker
{
    public class StatusAdapter
    {
        public string CoinText { get => LocalizationText.Instance.ToString("Status.Coin", this); }
        public string PowerText { get => LocalizationText.Instance.ToString("Status.Power", this); }
        public string Coin { get => Ichi.Common.BigIntegerText.ToString(Repositories.Instance.WalletRepository.Get().Coin); }
        public string Power {
            get {
                BigInteger power;
                foreach (var factory in Repositories.Instance.FactoryRepository.List()) {
                    power += factory.Power;
                }
                return Ichi.Common.BigIntegerText.ToString(power);
            }
        }
    }
}
