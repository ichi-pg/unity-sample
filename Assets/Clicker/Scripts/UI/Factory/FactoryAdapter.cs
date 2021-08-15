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
        public string LevelUpCost { get => "LvUp"+Common.NumericTextUtility.Omit(this.Factory.LevelUpCost); }//TODO
        public string BuyCost { get => "Buy"+Common.NumericTextUtility.Omit(this.Factory.BuyCost); }//TODO
        public string Power { get => "Power"+Common.NumericTextUtility.Omit(this.Factory.Power); }//TODO
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
            var factories = repository.ListBuyable();
            repository.LevelUp(this.Factory);
            foreach (var factory in repository.ListBuyable()) {
                if (factories.Any(t => t == factory)) {
                    continue;
                }
                //TODO 勢い余って二つ追加される場合がある(ビュー側のリストと照合すれば良い)
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
