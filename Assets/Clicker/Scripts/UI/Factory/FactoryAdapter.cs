using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Clicker
{
    public class FactoryAdapter
    {
        public Factory Factory { get; private set; }
        private FactoriesInjector factoriesInjector;

        public string Name { get => "Rank"+this.Factory.Rank+" Lv"+this.Factory.Level; }//TODO
        public string LevelUpCost { get => "LvUp"+Common.BigIntegerText.ToString(this.Factory.LevelUpCost); }//TODO
        public string BuyCost { get => "Buy"+Common.BigIntegerText.ToString(this.Factory.BuyCost); }//TODO
        public string Power { get => "Power"+Common.BigIntegerText.ToString(this.Factory.Power); }//TODO
        public bool BuyActive { get => this.Factory.IsLocked; }
        public bool BuyInteractable { get => Repositories.Instance.WalletRepository.Get().Coin >= this.Factory.BuyCost; }
        public bool LevelUpActive { get => !this.Factory.IsLocked; }
        public bool LevelUpInteractable { get => Repositories.Instance.WalletRepository.Get().Coin >= this.Factory.LevelUpCost; }

        public FactoryAdapter(Factory factory, FactoriesInjector factoriesInjector) {
            this.Factory = factory;
            this.factoriesInjector = factoriesInjector;
        }

        public void LevelUp() {
            if (!this.LevelUpActive) {
                return;
            }
            if (!this.LevelUpInteractable) {
                return;
            }
            var repository = Repositories.Instance.FactoryRepository;
            repository.LevelUp(this.Factory);
            foreach (var factory in repository.ListBuyable()) {
                this.factoriesInjector.Inject(factory);
            }
            Common.PropertyInjector.Modify();
        }

        public void Buy() {
            if (!this.BuyActive) {
                return;
            }
            if (!this.BuyInteractable) {
                return;
            }
            Repositories.Instance.FactoryRepository.Buy(this.Factory);
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
