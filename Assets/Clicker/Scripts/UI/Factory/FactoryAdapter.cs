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
        public bool BuyActive { get => !this.LevelUpActive; }
        public bool BuyInteractable { get => Repositories.Instance.WalletRepository.Get().Coin >= this.Factory.BuyCost; }
        public bool LevelUpActive { get; private set; }
        public bool LevelUpInteractable { get => Repositories.Instance.WalletRepository.Get().Coin >= this.Factory.LevelUpCost; }

        public FactoryAdapter(Factory factory, FactoriesInjector factoriesInjector) {
            this.Factory = factory;
            this.factoriesInjector = factoriesInjector;
            this.LevelUpActive = Repositories.Instance.FactoryRepository.List().Contains(factory);
        }

        public void LevelUp() {
            var repository = Repositories.Instance.FactoryRepository;
            var before = repository.GetBuyable();
            repository.LevelUp(this.Factory);
            var after = repository.GetBuyable();
            if (before != after) {
                this.factoriesInjector.Inject(after);
            }
        }

        public void Buy() {
            Repositories.Instance.FactoryRepository.Buy(this.Factory);
            this.LevelUpActive = true;
            Common.PropertyInjector.Modify();
        }

        public void Produce() {
            Repositories.Instance.FactoryRepository.Produce(this.Factory);
            Common.PropertyInjector.Modify();
        }
    }
}
