using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;
using Ichi.Common.Extensions;

namespace Ichi.Clicker.View
{
    public class GadgetView : MonoBehaviour, Common.IChildView<IGadget>
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

        private GadgetAdapter adapter;
        private IGadget factory;

        void Start() {
            this.levelUpButton.OnLongPressAsObservable(0.5d, 100d).Subscribe(_ => this.LevelUp()).AddTo(this);
        }

        public void Initialize(IGadget factory) {
            this.factory = factory;
            this.adapter = new GadgetAdapter(factory);
            this.factory.OnLevelUp.Subscribe(_ => this.OnAlter()).AddTo(this);
            DIContainer.CoinRepository.Item.OnAlter.Subscribe(_ => this.OnAlter()).AddTo(this);
            this.OnAlter();
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
            //TODO 生産ゲージアニメ
            //TODO 生産物アイコン差分
        }

        public void LevelUp() {
            if (this.adapter.CanLevelUp) {
                DIContainer.FromGadgetCategory(this.factory.Category).LevelUp(this.factory);
            }
            //TODO エフェクト
            //TODO SE
        }
    }
}
