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
    public class GadgetView : MonoBehaviour
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
        private Image gadgetImage;
        [SerializeField]
        private Image costImage;

        private IGadget gadget;
        private GadgetViewData data;

        void Start() {
            this.levelUpButton.OnLongPressAsObservable(0.5d, 100d).Subscribe(_ => this.LevelUp()).AddTo(this);
        }

        public void Initialize(IGadget gadget, GadgetViewData data) {
            this.gadget = gadget;
            this.data = data;
            this.gadget.OnLevelUp.Subscribe(_ => this.OnAlter()).AddTo(this);
            var item = DIContainer.ItemRepository.GetItem(ItemCategory.Coin);
            item.OnAlter.Subscribe(_ => this.OnAlter()).AddTo(this);
            this.OnAlter();
        }

        private void OnAlter() {
            this.label.text = this.data.Name(this.gadget);
            this.desc.text = this.data.Store + this.gadget.Power() + "/" + this.data.Unit;
            this.cost.text = this.gadget.Cost();
            this.cost.gameObject.SetActive(this.gadget.HasLevelUp);
            this.levelUp.text = this.gadget.LevelUp();
            this.levelUpButton.interactable = this.gadget.CanLevelUp();
            this.levelUpButton.gameObject.SetActive(this.gadget.HasLevelUp);
            this.lockImage.gameObject.SetActive(this.gadget.IsLock);
            this.gadgetImage.sprite = this.data.GadgetSprites[this.gadget.Rank - 1];
            this.costImage.sprite = this.data.CostSprite;
            this.costImage.gameObject.SetActive(this.gadget.HasLevelUp);
            //NEXT 生産ゲージアニメ
            //NEXT スキル実行ボタン
        }

        public void LevelUp() {
            if (this.gadget.CanLevelUp()) {
                DIContainer.FromGadgetCategory(this.gadget.Category).LevelUp(this.gadget);
            }
            //TODO エフェクト
            //TODO SE
        }
    }
}
