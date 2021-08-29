using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ichi.Clicker
{
    public class FeverAdsButton : MonoBehaviour
    {
        private Common.IAds ads;

        void Start() {
            this.ads = DIContainer.AdsCreator.Create();
            this.ads.RewardHandler += OnReward;
        }

        void OnDestroy() {
            this.ads.RewardHandler -= OnReward;
        }

        public void ShowAds() {
            this.ads.Play();
            //TODO ロード完了までボタン非活性
        }

        private void OnReward() {
            DIContainer.FeverRepository.CoolDown();
            //TODO クールダウンボタン非活性
            //TODO フィーバーボタン活性化
            //TODO 広告自身のクールタイム
        }
    }
}
