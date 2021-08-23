using System.Collections;
using System.Collections.Generic;

namespace Ichi.Clicker
{
    public class FactoryAdapter
    {
        public IFactory Factory { get; private set; }
        public string NameText { get => Dependency.LocalizationText.Localize("Factory.Name", this); }
        public string CostText { get => Dependency.LocalizationText.Localize("Factory.Cost", this); }
        public int Rank { get => this.Factory.Rank; }
        public int Level { get => this.Factory.Level; }
        public string Cost { get => Ichi.Common.BigIntegerText.ToString(this.Factory.Cost); }
        public string Power { get => Ichi.Common.BigIntegerText.ToString(this.Factory.Power); }
        public string NextPower { get => Ichi.Common.BigIntegerText.ToString(this.Factory.NextPower); }
        public bool LevelUpDisable { get => Dependency.ItemRepository.Coin.Quantity < this.Factory.Cost; }
        public bool BackgroundDisable { get => this.Factory.IsLocked; }

        public string Unit {
            get {
                switch (this.Factory.Category) {
                    case (int)FactoryCategory.Click:
                        return Dependency.LocalizationText.Localize("Unit.Click");
                    case (int)FactoryCategory.Auto:
                        return Dependency.LocalizationText.Localize("Unit.Auto");
                    default:
                        return "";
                }
            }
        }

        public FactoryAdapter(IFactory factory) {
            this.Factory = factory;
        }

        public void LevelUp() {
            if (this.LevelUpDisable) {
                return;
            }
            Dependency.FactoryRepository.LevelUp(this.Factory);
            Ichi.Common.DataInjector.Modify();
            //TODO シナリオ誘導
            //TODO フィールド表現
        }
    }
}
