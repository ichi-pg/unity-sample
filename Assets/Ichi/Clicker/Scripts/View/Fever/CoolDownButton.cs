using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

namespace Ichi.Clicker.View
{
    public class CoolDownButton : MonoBehaviour
    {
        [SerializeField]
        public Button button;
        private Common.IAds ads;

        void Start() {
            this.ads = DIContainer.AdsCreator.Create();
            this.ads.RewardHandler += this.OnReward;
            this.ads.LoadHandler += this.OnAlter;
            DIContainer.FeverRepository.OnAlter.Subscribe(_ => this.OnAlter()).AddTo(this);
            DIContainer.CoolDownRepository.OnAlter.Subscribe(_ => this.OnAlter()).AddTo(this);
            this.button.OnClickAsObservable().Subscribe(_ => this.PlayAds()).AddTo(this);
            this.OnAlter();
        }

        private void OnAlter() {
            this.button.interactable = this.ads.IsLoaded &&
                DIContainer.FeverRepository.CoolTime > TimeSpan.Zero &&
                DIContainer.CoolDownRepository.CoolTime <= TimeSpan.Zero &&
                DIContainer.FeverRepository.TimeLeft <= TimeSpan.Zero;
        }

        public void PlayAds() {
            this.ads.Play();
        }

        private void OnReward() {
            DIContainer.CoolDownRepository.CoolDown();
            //TODO エフェクト
            //TODO SE
        }
    }
}
