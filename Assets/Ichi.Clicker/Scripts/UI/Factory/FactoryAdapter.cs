using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Clicker
{
    public class FactoryAdapter
    {
        public Factory Factory { get; private set; }
        public string NameText { get => LocalizationText.Instance.ToString("Factory.Name", this); }
        public string CostText { get => LocalizationText.Instance.ToString("Factory.Cost", this); }
        public int Rank { get => this.Factory.Rank; }
        public int Level { get => this.Factory.Level; }
        public string Cost { get => Common.BigIntegerText.ToString(this.Factory.Cost); }
        public string Power { get => Common.BigIntegerText.ToString(this.Factory.Power); }
        public string NextPower { get => Common.BigIntegerText.ToString(this.Factory.NextPower); }
        public bool LevelUpDisable { get => Repositories.Instance.WalletRepository.Get().Coin < this.Factory.Cost; }
        public bool BackgroundDisable { get => this.Factory.IsLocked; }

        public FactoryAdapter(Factory factory) {
            this.Factory = factory;
        }

        public void LevelUp() {
            if (this.LevelUpDisable) {
                return;
            }
            Repositories.Instance.FactoryRepository.LevelUp(this.Factory);
            Common.DataInjector.Modify();
        }

        public void Produce() {
            if (this.Factory.IsLocked) {
                return;
            }
            Repositories.Instance.FactoryRepository.Produce(this.Factory);
            Common.DataInjector.Modify();
        }
    }
}
