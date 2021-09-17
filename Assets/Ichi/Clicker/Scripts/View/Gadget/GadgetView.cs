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
        private Sprite[] gadgetSprites;
        private Sprite costSprite;

        void Start() {
            this.levelUpButton.OnLongPressAsObservable(0.5d, 100d).Subscribe(_ => this.LevelUp()).AddTo(this);
        }

        public void Initialize(IGadget gadget, Sprite[] gadgetSprites, Sprite costSprite) {
            this.gadget = gadget;
            this.gadgetSprites = gadgetSprites;
            this.costSprite = costSprite;
            this.gadget.OnLevelUp.Subscribe(_ => this.OnAlter()).AddTo(this);
            var item = DIContainer.ItemRepository.GetItem(ItemCategory.Coin);
            item.OnAlter.Subscribe(_ => this.OnAlter()).AddTo(this);
            this.OnAlter();
        }

        private void OnAlter() {
            this.label.text = this.gadget.Name();
            this.desc.text = this.gadget.Store() + this.gadget.Power() + "/" + this.gadget.Unit();
            this.cost.text = this.gadget.Cost();
            this.levelUp.text = this.gadget.LevelUp();
            this.levelUpButton.interactable = this.gadget.CanLevelUp();
            this.levelUpButton.gameObject.SetActive(!this.gadget.IsLock);
            this.lockImage.gameObject.SetActive(this.gadget.IsLock);
            this.gadgetImage.sprite = this.gadgetSprites[this.gadget.Rank - 1];
            this.costImage.sprite = this.costSprite;
            //NEXT 生産ゲージアニメ
            //NEXT Clicker以外開放コスト描画するのおかしい（Clickerもドロップにしたら全部非表示でいい）
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
