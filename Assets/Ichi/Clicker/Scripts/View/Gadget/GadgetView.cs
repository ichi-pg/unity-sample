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
        private ISkillButton cachedSkillButon;

        public void Initialize(IGadget gadget) {
            this.gadget = gadget;
            this.data = this.dataList.GetViewData(gadget.GadgetCategory);
            this.gadget.OnLevelUp.Subscribe(_ => this.OnAlter()).AddTo(this);
            this.levelUpButton.OnLongPressAsObservable(0.5d, 100d).Subscribe(_ => this.LevelUp()).AddTo(this);
            DIContainer.EnemyRepository.OnDrop.Where(x => x == gadget).Subscribe(_ => this.OnAlter()).AddTo(this);
            DIContainer.ItemRepository.GetItem(gadget.CostCategory).OnAlter.Subscribe(_ => this.OnAlter()).AddTo(this);
            //スキル用の処理
            switch (gadget.WorkCategory) {
                case WorkCategory.Fever:
                    this.cachedSkillButon = this.feverButton;
                    break;
                case WorkCategory.CoolDown:
                    this.cachedSkillButon = this.coolDownButton;
                    break;
            }
            if (this.cachedSkillButon != null) {
                this.coolTimeGauge.SetCategory(gadget.WorkCategory.Cast());
                this.coolTimeView.SetCategory(gadget.WorkCategory.Cast());
                DIContainer.FeverRepository.OnAlter.Subscribe(_ => this.OnAlter()).AddTo(this);
                DIContainer.CoolDownRepository.OnAlter.Subscribe(_ => this.OnAlter()).AddTo(this);
            }
            this.coolTimeGauge.gameObject.SetActive(this.cachedSkillButon != null);
            this.coolTimeView.gameObject.SetActive(this.cachedSkillButon != null);
            this.skillButton.enabled = this.cachedSkillButon != null;
            this.feverButton.enabled = this.cachedSkillButon == this.feverButton;
            this.coolDownButton.enabled = this.cachedSkillButon == this.coolDownButton;
            this.OnAlter();
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
            this.tap.gameObject.SetActive(this.cachedSkillButon != null ? this.cachedSkillButon.IsInteractable : false);
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
