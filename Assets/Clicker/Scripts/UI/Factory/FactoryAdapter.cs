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
        public string Cost { get => Common.BigIntegerText.ToString(this.Factory.Cost)+"\n("+Common.BigIntegerText.ToString(this.Factory.Cost / (this.Factory.NextPower - this.Factory.Power))+")"; }//TODO
        public string Power { get => "Power"+Common.BigIntegerText.ToString(this.Factory.IsLocked ? this.Factory.NextPower : this.Factory.Power); }//TODO
        public bool LevelUpDisable { get => Repositories.Instance.WalletRepository.Get().Coin < this.Factory.Cost; }
        public bool BackgroundDisable { get => this.Factory.IsLocked; }

        public FactoryAdapter(Factory factory, FactoriesInjector factoriesInjector) {
            this.Factory = factory;
            this.factoriesInjector = factoriesInjector;
        }

        public void LevelUp() {
            if (this.LevelUpDisable) {
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
