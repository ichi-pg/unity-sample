using System.Collections;
using System.Collections.Generic;

namespace Clicker
{
    public class FactoryAdapter
    {
        public Factory Factory { get; private set; }
        private FactoriesInjector factoriesInjector;

        public string Name { get => "Rank"+this.Factory.Rank+" Lv"+this.Factory.Level; }//TODO
        public string LevelUpCost { get => "LvUp"+Common.NumericTextUtility.Omit(this.Factory.LevelUpCost); }//TODO
        public string BuyCost { get => "Buy"+Common.NumericTextUtility.Omit(this.Factory.BuyCost); }//TODO
        public string Power { get => "Power"+Common.NumericTextUtility.Omit(this.Factory.Power); }//TODO
        public bool CanBuy { get { return Repositories.Instance.WalletRepository.Get().Coin >= this.Factory.LevelUpCost; } }
        public bool CanLevelUp { get { return Repositories.Instance.WalletRepository.Get().Coin >= this.Factory.LevelUpCost; } }

        public FactoryAdapter(Factory factory, FactoriesInjector factoriesInjector) {
            this.Factory = factory;
            this.factoriesInjector = factoriesInjector;
        }

        public void LevelUp() {
            Repositories.Instance.FactoryRepository.LevelUp(this.Factory);
            this.factoriesInjector.Reflesh();//TODO 数が増えた時だけ足すだけ
        }

        public void Buy() {
            Repositories.Instance.FactoryRepository.Buy(this.Factory);
            this.factoriesInjector.Reflesh();//TODO 数が増えた時だけ足すだけ
        }

        public void Produce() {
            Repositories.Instance.FactoryRepository.Produce(this.Factory);
            Common.PropertyInjector.Modify();
        }
    }
}
