using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

namespace Ichi.Clicker.View
{
    public class CoolDownModal : MonoBehaviour
    {
        [SerializeField]
        private Button adsButton;
        [SerializeField]
        private Common.ModalCloser closer;

        private Common.IAds ads;

        void Start() {
            this.ads = DIContainer.AdsCreator.Create();
            this.ads.RewardHandler += this.OnReward;
            this.ads.LoadHandler += this.OnLoadAds;
            this.adsButton.OnClickAsObservable().Subscribe(_ => this.PlayAds()).AddTo(this);
            this.OnLoadAds();
        }

        private void OnLoadAds() {
            this.adsButton.interactable = this.ads.IsLoaded;
        }

        private void PlayAds() {
            this.ads.Play();
        }

        private void OnReward() {
            DIContainer.CoolDownRepository.CoolDown();
            this.closer.Close();
            //TODO エフェクト
            //TODO SE
        }
    }
}
