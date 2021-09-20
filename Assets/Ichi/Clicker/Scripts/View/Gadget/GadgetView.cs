using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;
using DG.Tweening;
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
        private Text tap;
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
        [SerializeField]
        private GadgetViewDataList dataList;

        private IGadget gadget;
        private GadgetViewData data;

        public void Initialize(IGadget gadget) {
            this.gadget = gadget;
            this.data = this.dataList.GetViewData(gadget.GadgetCategory);
            this.gadget.OnLevelUp.Subscribe(_ => this.OnAlter()).AddTo(this);
            this.levelUpButton.OnLongPressAsObservable(0.5d, 100d).Subscribe(_ => this.LevelUp()).AddTo(this);
            this.tap.gameObject.SetActive(false);
            DIContainer.EnemyRepository.OnDrop.Where(x => x == gadget).Subscribe(_ => this.OnAlter()).AddTo(this);
            DIContainer.ItemRepository.GetItem(gadget.CostCategory).OnAlter.Subscribe(_ => this.OnAlter()).AddTo(this);
            switch (gadget.WorkCategory) {
                case WorkCategory.Fever:
                    this.UpdateSkill<FeverButton>().Forget();
                    break;
                case WorkCategory.CoolDown:
                    this.UpdateSkill<CoolDownButton>().Forget();
                    break;
            }
            this.OnAlter();
        }

        private async UniTask UpdateSkill<T>() where T : Component, ISkillButton {
            var button = this.gameObject.AddComponent<Button>();
            this.gameObject.AddComponent<T>().SetButton(button);
            var token = this.GetCancellationTokenOnDestroy();
            await UniTask.Yield(PlayerLoopTiming.Update, cancellationToken: token);
            while (true) {
                this.tap.gameObject.SetActive(button.interactable);
                this.desc.text = this.gadget.Desc();
                await UniTask.Delay(TimeSpan.FromSeconds(1), cancellationToken: token);
            }
            //TODO 実行中であると分かりやすいアニメーション
        }

        private void OnAlter() {
            this.label.text = this.gadget.Name();
            this.descImage.sprite = this.data.DescSprite;
            this.descImage.gameObject.SetActive(this.data.DescSprite != null);
            this.desc.text = this.gadget.Desc();
            this.cost.text = this.gadget.Cost();
            this.cost.gameObject.SetActive(this.gadget.HasLevelUp);
            this.levelUpButton.interactable = this.gadget.CanLevelUp();
            this.levelUpButton.gameObject.SetActive(this.gadget.HasLevelUp);
            this.disableImage.gameObject.SetActive(!this.gadget.IsBought);
            this.lockImage.gameObject.SetActive(this.gadget.IsLock);
            this.gadgetImage.sprite = this.data.GadgetSprite(gadget);
            this.costImage.sprite = this.data.CostSprite;
            this.costImage.gameObject.SetActive(this.gadget.HasLevelUp);
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
