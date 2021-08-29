using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Ichi.Clicker
{
    [RequireComponent(typeof(Button))]
    public class FeverAdsButton : MonoBehaviour
    {
        private Button button;
        private Common.IAds ads;

        void Start() {
            this.button = this.GetComponent<Button>();
            this.ads = DIContainer.AdsCreator.Create();
            this.ads.RewardHandler += OnReward;
            DIContainer.FeverRepository.AlterHandler += this.OnAlter;
        }

        void OnDestroy() {
            DIContainer.FeverRepository.AlterHandler -= this.OnAlter;
        }

        public void PlayAds() {
            this.ads.Play();
            //TODO ロード完了までボタン非活性
        }

        private void OnReward() {
            DIContainer.FeverRepository.CoolDown();
            //TODO 広告自身のクールタイム
        }

        private void OnAlter() {
            //TODO クールダウンボタン非活性
        }
    }
}
