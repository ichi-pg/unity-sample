using System.Collections;
using System.Collections.Generic;
using System;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;

namespace Ichi.Common
{
    public class GoogleAds :  IAds
    {
        private RewardedAd rewardedAd;
        public event Action RewardHandler;

        public GoogleAds() {
            this.CreateAndLoadRewardedAd();
            //TODO new警告が出るの気持ち悪い
            //TODO ダミーGameObjectが残ることがある
        }

        public void Play() {
            this.rewardedAd.Show();
        }

        private void CreateAndLoadRewardedAd() {
            //TODO 外部引数化
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
        }

        private void HandleUserEarnedReward(object sender, Reward args) {
            this.RewardHandler?.Invoke();
        }

        private void HandleRewardedAdClosed(object sender, EventArgs args) {
            this.CreateAndLoadRewardedAd();
        }
    }
}
