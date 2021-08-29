using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;

namespace Ichi.Clicker
{
    public class FeverAdsButton : MonoBehaviour
    {
        private RewardedAd rewardedAd;

        void Start() {
            this.CreateAndLoadRewardedAd();
        }

        public void ShowAds() {
            this.rewardedAd.Show();
            //TODO ロード完了までボタン非活性
        }

        private void CreateAndLoadRewardedAd() {
            #if UNITY_ANDROID
                var adUnitId = "ca-app-pub-3940256099942544/5224354917";
            #elif UNITY_IPHONE
                var adUnitId = "ca-app-pub-3940256099942544/1712485313";
            #else
                var adUnitId = "unexpected_platform";
            #endif
            this.rewardedAd = new RewardedAd(adUnitId);
            this.rewardedAd.OnUserEarnedReward += this.HandleUserEarnedReward;
            this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;
            this.rewardedAd.LoadAd(new AdRequest.Builder().Build());
            //TODO Common化
        }

        private void HandleUserEarnedReward(object sender, Reward args) {
            DIContainer.FeverRepository.CoolDown();
            //TODO クールダウンボタン非活性
            //TODO フィーバーボタン活性化
            //TODO 広告自身のクールタイム
        }

        private void HandleRewardedAdClosed(object sender, EventArgs args) {
            this.CreateAndLoadRewardedAd();
        }
    }
}
