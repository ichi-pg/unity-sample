using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Clicker
{
    public class FactoryAdapter
    {
        public Factory Factory { get; private set; }
        private FactoriesInjector factoriesInjector;

        public string Name { get => "Rank"+this.Factory.Rank+(this.Factory.IsLocked ? "" : " Lv"+this.Factory.Level); }//TODO
        public string Cost { get => (this.Factory.IsLocked ? "Buy" : "LvUp")+Common.BigIntegerText.ToString(this.Factory.Cost); }//TODO
        public string Power { get => "Power"+Common.BigIntegerText.ToString(this.Factory.IsLocked ? this.Factory.NextPower : this.Factory.Power); }//TODO
        public string Next { get => "Next"+Common.BigIntegerText.ToString(this.Factory.Cost / (this.Factory.NextPower - this.Factory.Power)); }//TODO
        public bool LevelUpInteractable { get => Repositories.Instance.WalletRepository.Get().Coin >= this.Factory.Cost; }

        public FactoryAdapter(Factory factory, FactoriesInjector factoriesInjector) {
            this.Factory = factory;
            this.factoriesInjector = factoriesInjector;
        }

        public void LevelUp() {
            if (!this.LevelUpInteractable) {
                return;
            }
            Repositories.Instance.FactoryRepository.LevelUp(this.Factory);
            Common.PropertyInjector.Modify();
        }

        public void Produce() {
            if (this.Factory.IsLocked) {
                return;
            }
            Repositories.Instance.FactoryRepository.Produce(this.Factory);
            Common.PropertyInjector.Modify();
        }
    }
}
