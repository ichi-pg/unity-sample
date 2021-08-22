using System.Collections;
using System.Collections.Generic;

namespace Ichi.Clicker
{
    public class FactoryAdapter
    {
        public Factory Factory { get; private set; }
        public string NameText { get => Dependency.LocalizationText.Localize("Factory.Name", this); }
        public string CostText { get => Dependency.LocalizationText.Localize("Factory.Cost", this); }
        public int Rank { get => this.Factory.Rank; }
        public int Level { get => this.Factory.Level; }
        public string Cost { get => Ichi.Common.BigIntegerText.ToString(this.Factory.Cost); }
        public string Power { get => Ichi.Common.BigIntegerText.ToString(this.Factory.Power); }
        public string NextPower { get => Ichi.Common.BigIntegerText.ToString(this.Factory.NextPower); }
        public bool LevelUpDisable { get => Dependency.WalletRepository.Get().Coin < this.Factory.Cost; }
        public bool BackgroundDisable { get => this.Factory.IsLocked; }

        public FactoryAdapter(Factory factory) {
            this.Factory = factory;
        }

        public void LevelUp() {
            if (this.LevelUpDisable) {
                return;
            }
            Dependency.FactoryRepository.LevelUp(this.Factory);
            Ichi.Common.DataInjector.Modify();
        }
    }
}
