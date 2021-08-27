using System.Collections;
using System.Collections.Generic;

namespace Ichi.Clicker
{
    public class FactoryAdapter
    {
        public IFactory Factory { get; private set; }
        public string NameText { get => DIContainer.TextLocalizer.Localize("Factory.Name", this); }
        public string CostText { get => DIContainer.TextLocalizer.Localize("Factory.Cost", this); }
        public int Rank { get => this.Factory.Rank; }
        public int Level { get => this.Factory.Level; }
        public string Cost { get => Ichi.Common.BigIntegerText.ToString(this.Factory.Cost); }
        public string Power { get => Ichi.Common.BigIntegerText.ToString(this.Factory.Power); }
        public string NextPower { get => Ichi.Common.BigIntegerText.ToString(this.Factory.NextPower); }
        public bool LevelUpDisable { get => this.Factory.IsLock || DIContainer.CoinRepository.Coin.Quantity < this.Factory.Cost; }
        public bool BackgroundDisable { get => !this.Factory.IsBought; }

        public string Unit {
            get {
                switch (this.Factory.Category) {
                    case (int)FactoryCategory.Click:
                        return DIContainer.TextLocalizer.Localize("Unit.Click");
                    case (int)FactoryCategory.Auto:
                        return DIContainer.TextLocalizer.Localize("Unit.Auto");
                    default:
                        return "";
                }
            }
        }

        public FactoryAdapter(IFactory factory) {
            this.Factory = factory;
            //TODO 25レベルでのパワー2倍、50レベルでのフィーバー倍率アップのアピール表示
        }

        public void LevelUp() {
            if (this.LevelUpDisable) {
                return;
            }
            DIContainer.FactoryRepository.LevelUp(this.Factory);
            Ichi.Common.DataInjector.Modify();
            //TODO シナリオ
            //TODO キャラ
            //TODO 背景
            //TODO インクリメントエフェクト
            //TODO 長押し
        }
    }
}
