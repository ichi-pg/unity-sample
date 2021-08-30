using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Ichi.Clicker
{
    public class FactoryView : MonoBehaviour
    {
        [SerializeField]
        private Text label;
        [SerializeField]
        private Text cost;
        [SerializeField]
        private Button levelUpButton;
        [SerializeField]
        private Image background;

        private FactoryAdapter adapter;
        private IFactory factory;

        public void Initialize(IFactory factory) {
            this.factory = factory;
            this.adapter = new FactoryAdapter(factory);
            this.factory.AlterHandler += this.OnAlter;
            DIContainer.CoinRepository.Coin.AlterHandler += this.OnAlter;
            this.OnAlter();
        }

        void OnDestroy() {
            if (this.factory != null) {
                this.factory.AlterHandler -= this.OnAlter;
            }
            DIContainer.CoinRepository.Coin.AlterHandler -= this.OnAlter;
        }

        private void OnAlter() {
            this.label.text = DIContainer.TextLocalizer.Localize("Factory.Name", this.adapter);
            this.cost.text = DIContainer.TextLocalizer.Localize("Factory.Cost", this.adapter);
            this.cost.color = Inflation.IsInflation(this.factory.Level + 1) ? Color.red : Color.black;
            this.levelUpButton.interactable = this.adapter.CanLevelUp;
            this.background.color = this.factory.IsBought ? Color.white : Color.gray;
        }

        public void LevelUp() {
            DIContainer.FactoryRepository.LevelUp(this.factory);
        }
    }
}
