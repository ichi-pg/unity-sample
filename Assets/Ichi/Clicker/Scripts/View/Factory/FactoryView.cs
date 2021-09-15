using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;
using Ichi.Common.Extensions;
using Zenject;

namespace Ichi.Clicker.View
{
    public class FactoryView : MonoBehaviour, Common.IChildView<IFactory>
    {
        [Inject]
        private ICoinRepository coinRepository;
        [Inject]
        private Common.ITextLocalizer textLocalizer;
        [Inject]
        private IFactoryRepositories factoryRepositories;

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

        void Start() {
            this.levelUpButton.OnLongPressAsObservable(0.5d, 100d).Subscribe(_ => this.LevelUp()).AddTo(this);
        }

        public void Initialize(IFactory factory) {
            this.factory = factory;
            this.adapter = new FactoryAdapter(factory);
            this.factory.OnLevelUp.Subscribe(_ => this.OnAlter()).AddTo(this);
            this.coinRepository.Item.OnAlter.Subscribe(_ => this.OnAlter()).AddTo(this);
            this.OnAlter();
        }

        private void OnAlter() {
            this.label.text = this.factory.IsBought ? this.adapter.Name + " Lv" + this.factory.Level : this.adapter.Name;
            this.desc.text = this.textLocalizer.Localize("Coin") + this.adapter.Power + "/" + this.adapter.Unit;
            this.cost.text = this.adapter.Cost;
            this.levelUp.text = this.textLocalizer.Localize(this.factory.IsBought ? "LevelUp" : "Buy");
            this.levelUpButton.interactable = this.adapter.CanLevelUp;
            this.levelUpButton.gameObject.SetActive(!this.factory.IsLock);
            this.lockImage.gameObject.SetActive(this.factory.IsLock);
            this.icon.sprite = this.sprites[this.factory.Rank - 1];
            //TODO 生産ゲージアニメ
            //TODO 生産物アイコン差分
        }

        public void LevelUp() {
            if (this.adapter.CanLevelUp) {
                this.factoryRepositories.Get(this.factory.Category).LevelUp(this.factory);
            }
            //NOTE エフェクト
            //NOTE SE
        }
    }
}
