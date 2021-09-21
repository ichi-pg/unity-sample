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
        private CanvasGroup tap;
        [SerializeField]
        private Button levelUpButton;
        [SerializeField]
        private Button skillButton;
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
        private Image feverImage;
        [SerializeField]
        private GadgetViewDataList dataList;
        [SerializeField]
        private FeverButton feverButton;
        [SerializeField]
        private CoolDownButton coolDownButton;

        private IGadget gadget;
        private GadgetViewData data;

        public void Initialize(IGadget gadget) {
            this.gadget = gadget;
            this.data = this.dataList.GetViewData(gadget.GadgetCategory);
            this.gadget.OnLevelUp.Subscribe(_ => this.OnAlter()).AddTo(this);
            this.levelUpButton.OnLongPressAsObservable(0.5d, 100d).Subscribe(_ => this.LevelUp()).AddTo(this);
            DIContainer.EnemyRepository.OnDrop.Where(x => x == gadget).Subscribe(_ => this.OnAlter()).AddTo(this);
            DIContainer.ItemRepository.GetItem(gadget.CostCategory).OnAlter.Subscribe(_ => this.OnAlter()).AddTo(this);
            this.OnAlter();
            //スキル用の処理
            this.tap.gameObject.SetActive(false);
            this.feverImage.gameObject.SetActive(false);
            this.skillButton.enabled = false;
            this.feverButton.enabled = false;
            this.coolDownButton.enabled = false;
            switch (gadget.WorkCategory) {
                case WorkCategory.Fever:
                    this.feverButton.enabled = true;
                    this.UpdateSkill(this.feverButton).Forget();
                    break;
                case WorkCategory.CoolDown:
                    this.coolDownButton.enabled = true;
                    this.UpdateSkill(this.coolDownButton).Forget();
                    break;
            }
        }

        private async UniTask UpdateSkill(ISkillButton skillButton) {
            this.skillButton.enabled = true;
            var token = this.GetCancellationTokenOnDestroy();
            await UniTask.Yield(PlayerLoopTiming.Update, cancellationToken: token);
            this.feverImage.gameObject.SetActive(true);
            while (true) {
                this.tap.gameObject.SetActive(skillButton.IsInteractable);
                this.feverImage.fillAmount = skillButton.WorkRate;
                this.desc.text = this.gadget.Desc();
                await UniTask.Delay(TimeSpan.FromMilliseconds(100), cancellationToken: token);
            }
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
