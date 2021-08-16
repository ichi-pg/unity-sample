using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Linq;

namespace Clicker
{
    public class StatusAdapter
    {
        public string Level { get => "Level"+Factory.GetPlayerLevel(Repositories.Instance.FactoryRepository.List());}
        public string NextLevel { get => "NextLevel"+Factory.GetNextPlayerLevel(Repositories.Instance.FactoryRepository.List());}
        public string Coin { get => "Coin"+Common.BigIntegerText.ToString(Repositories.Instance.WalletRepository.Get().Coin); }//TODO
        public string Power {
            get {
                BigInteger power;
                foreach (var factory in Repositories.Instance.FactoryRepository.List()) {
                    power += factory.Power;
                }
                return "Power"+Common.BigIntegerText.ToString(power);//TODO
            }
        }
    }
}
