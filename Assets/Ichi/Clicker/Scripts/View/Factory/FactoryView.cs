using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Ichi.Clicker
{
    public class FactoryView : MonoBehaviour
    {
        [SerializeField]
        private Text name;
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
            this.OnAlter();
        }

        void OnDestroy() {
            if (this.factory != null) {
                this.factory.AlterHandler -= this.OnAlter;
            }
        }

        private void OnAlter() {
            this.name.text = DIContainer.TextLocalizer.Localize("Factory.Name", this.adapter);
            this.cost.text = DIContainer.TextLocalizer.Localize("Factory.Cost", this.adapter);
            this.levelUpButton.interactable = this.adapter.CanLevelUp;
            this.background.color = this.factory.IsBought ? Color.white : Color.gray;
        }

        public void LevelUp() {
            DIContainer.FactoryRepository.LevelUp(this.factory);
            //TODO シナリオ
            //TODO キャラ
            //TODO シェーダー
            //TODO SE
            //TODO BGM
            //TODO 背景
            //TODO GUI
            //TODO インクリメントエフェクト
            //TODO 長押し
            //TODO 25レベルでの倍率アップのアピール表示
        }
    }
}
