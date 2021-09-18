using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System;
using Cysharp.Threading.Tasks;
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
        private Button levelUpButton;
        [SerializeField]
        private Image disableImage;
        [SerializeField]
        private Image lockImage;
        [SerializeField]
        private Image gadgetImage;
        [SerializeField]
        private Image descImage;
        [SerializeField]
        private Image costImage;

        private IGadget gadget;
        private GadgetViewData data;

        public void Initialize(IGadget gadget, GadgetViewData data) {
            this.gadget = gadget;
            this.data = data;
            this.gadget.OnLevelUp.Subscribe(_ => this.OnAlter()).AddTo(this);
            this.levelUpButton.OnLongPressAsObservable(0.5d, 100d).Subscribe(_ => this.LevelUp()).AddTo(this);
            DIContainer.EnemyRepository.OnDrop.Where(x => x == gadget).Subscribe(_ => this.OnAlter()).AddTo(this);
            DIContainer.ItemRepository.GetItem(gadget.CostCategory).OnAlter.Subscribe(_ => this.OnAlter()).AddTo(this);
            switch (gadget.WorkCategory) {
                case WorkCategory.Fever:
                    this.gameObject.AddComponent<FeverButton>().button = this.gameObject.AddComponent<Button>();
                    this.UpdateDesc().Forget();
                    break;
                case WorkCategory.CoolDown:
                    this.gameObject.AddComponent<CoolDownButton>().button = this.gameObject.AddComponent<Button>();
                    this.UpdateDesc().Forget();
                    break;
            }
            this.OnAlter();
        }

        private async UniTask UpdateDesc() {
            var token = this.GetCancellationTokenOnDestroy();
            while (true) {
                this.desc.text = this.gadget.Desc();
                await UniTask.Delay(TimeSpan.FromSeconds(1), cancellationToken: token);
            }
            //TODO タップできそうなアピール
            //TODO 実行中であると分かりやすいアニメーション
        }

        private void OnAlter() {
            this.label.text = this.data.Name(this.gadget);
            this.descImage.sprite = this.data.DescSprite;
            this.descImage.gameObject.SetActive(this.data.DescSprite != null);
            this.desc.text = this.gadget.Desc();
            this.cost.text = this.gadget.Cost();
            this.cost.gameObject.SetActive(this.gadget.HasLevelUp);
            this.levelUpButton.interactable = this.gadget.CanLevelUp();
            this.levelUpButton.gameObject.SetActive(this.gadget.HasLevelUp);
            this.disableImage.gameObject.SetActive(!this.gadget.IsBought);
            this.lockImage.gameObject.SetActive(this.gadget.IsLock);
            this.gadgetImage.sprite = this.data.GadgetSprites[this.gadget.Rank - 1];
            this.costImage.sprite = this.data.CostSprite;
            this.costImage.gameObject.SetActive(this.gadget.HasLevelUp);
            //NEXT 生産ゲージアニメ
        }

        public void LevelUp() {
            if (this.gadget.CanLevelUp()) {
                DIContainer.GadgetRepository.LevelUp(this.gadget);
            }
            //TODO エフェクト
            //TODO SE
        }
    }
}
