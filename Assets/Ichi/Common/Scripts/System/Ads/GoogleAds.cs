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
        public event Action LoadHandler;
        public bool IsLoaded { get => this.rewardedAd.IsLoaded(); }

        public GoogleAds() {
            this.CreateAndLoadRewardedAd();
            //NOTE new警告が出るの気持ち悪い（仕様っぽい）
            //NOTE ダミーGameObjectが残ることがある
            //TODO UnityAdsも試したい
            //TODO Loadedまでボタン非表示じゃなくてダミー広告出すのが主流？
        }

        public void Play() {
            if (!this.IsLoaded) {
                throw new Exception("Invalid loaded.");
            }
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
            this.rewardedAd.OnAdLoaded += this.HandleRewardedAdLoaded;
            this.rewardedAd.OnUserEarnedReward += this.HandleUserEarnedReward;
            this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;
            this.rewardedAd.LoadAd(new AdRequest.Builder().Build());
            this.LoadHandler?.Invoke();
        }

        public void HandleRewardedAdLoaded(object sender, EventArgs args) {
            this.LoadHandler?.Invoke();
        }

        private void HandleUserEarnedReward(object sender, Reward args) {
            this.RewardHandler?.Invoke();
        }

        private void HandleRewardedAdClosed(object sender, EventArgs args) {
            this.CreateAndLoadRewardedAd();
        }
    }
}
