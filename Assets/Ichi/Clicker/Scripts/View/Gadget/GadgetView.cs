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
        private GadgetViewDataList dataList;
        [SerializeField]
        private FeverButton feverButton;
        [SerializeField]
        private CoolDownButton coolDownButton;
        [SerializeField]
        private CoolTimeGauge coolTimeGauge;
        [SerializeField]
        private CoolTimeView coolTimeView;

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
            this.coolTimeGauge.gameObject.SetActive(true);
            this.coolTimeView.gameObject.SetActive(true);
            this.skillButton.enabled = true;
            this.feverButton.enabled = false;
            this.coolDownButton.enabled = false;
            switch (gadget.WorkCategory) {
                case WorkCategory.Fever:
                    this.feverButton.enabled = true;
                    this.coolTimeGauge.SetCategory(SkillCategory.Fever);
                    this.coolTimeView.SetCategory(SkillCategory.Fever);
                    this.UpdateSkill(this.feverButton).Forget();
                    break;
                case WorkCategory.CoolDown:
                    this.coolDownButton.enabled = true;
                    this.coolTimeGauge.SetCategory(SkillCategory.CoolDown);
                    this.coolTimeView.SetCategory(SkillCategory.CoolDown);
                    this.UpdateSkill(this.coolDownButton).Forget();
                    break;
                default:
                    this.skillButton.enabled = false;
                    this.coolTimeGauge.gameObject.SetActive(false);
                    this.coolTimeView.gameObject.SetActive(false);
                    break;
            }
        }

        private async UniTask UpdateSkill(ISkillButton skillButton) {
            var token = this.GetCancellationTokenOnDestroy();
            await UniTask.Yield(PlayerLoopTiming.Update, cancellationToken: token);
            while (true) {
                //TODO これだけなら通知でいい
                this.tap.gameObject.SetActive(skillButton.IsInteractable);
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
