using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Ichi.Clicker.View
{
    public class FactoryView : MonoBehaviour, Common.IChildView<IFactory>
    {
        [SerializeField]
        private Text label;
        [SerializeField]
        private Text desc;
        [SerializeField]
        private Text cost;
        [SerializeField]
        private Text levelUp;
        [SerializeField]
        private Button levelUpButton;
        [SerializeField]
        private Image lockImage;
        [SerializeField]
        private Image icon;
        [SerializeField]
        private Sprite[] sprites;

        private FactoryAdapter adapter;
        private IFactory factory;

        public void Initialize(IFactory factory) {
            this.factory = factory;
            this.adapter = new FactoryAdapter(factory);
            this.factory.AlterHandler += this.OnAlter;
            DIContainer.CoinRepository.Coin.AlterHandler += this.OnAlter;
            this.OnAlter();
        }

        public void OnDestroy() {
            if (this.factory != null) {
                this.factory.AlterHandler -= this.OnAlter;
            }
            DIContainer.CoinRepository.Coin.AlterHandler -= this.OnAlter;
        }

        private void OnAlter() {
            this.label.text = this.factory.IsBought ? this.adapter.Name + " Lv" + this.factory.Level : this.adapter.Name;
            this.desc.text = DIContainer.TextLocalizer.Localize("Coin") + this.adapter.Power + "/" + this.adapter.Unit;
            this.cost.text = this.adapter.Cost;
            this.levelUp.text = DIContainer.TextLocalizer.Localize(this.factory.IsBought ? "LevelUp" : "Buy");
            this.levelUpButton.interactable = this.adapter.CanLevelUp;
            this.levelUpButton.gameObject.SetActive(!this.factory.IsLock);
            this.lockImage.gameObject.SetActive(this.factory.IsLock);
            this.icon.sprite = this.sprites[this.factory.Rank - 1];
        }

        public void LevelUp() {
            if (this.adapter.CanLevelUp) {
                DIContainer.FromFactoryCategory(this.factory.Category).LevelUp(this.factory);
            }
            //TODO エフェクト
            //TODO SE
        }
    }
}
