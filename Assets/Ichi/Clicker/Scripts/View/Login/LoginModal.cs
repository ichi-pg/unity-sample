using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Ichi.Clicker
{
    [RequireComponent(typeof(Common.CloseModalButton))]
    public class LoginModal : MonoBehaviour
    {
        [SerializeField]
        private Text quantity;
        [SerializeField]
        private Image percentage;
        [SerializeField]
        private Image percentageParent;
        [SerializeField]
        private Button adsButton;
        private Common.CloseModalButton closeButton;

        private Common.IAds ads;

        void Start() {
            this.closeButton = this.GetComponent<Common.CloseModalButton>();
            this.quantity.text = Common.BigIntegerText.ToString(DIContainer.LoginRepository.Quantity);
            //TODO ゲージ処理の共通化
            var parentSize = this.percentageParent.rectTransform.sizeDelta;
            var size = this.percentage.rectTransform.sizeDelta;
            size.x = parentSize.x * DIContainer.LoginRepository.Percentage;
            this.percentage.rectTransform.sizeDelta = size;
            this.ads = DIContainer.AdsCreator.Create();
            this.ads.RewardHandler += this.OnReward;
            this.ads.LoadHandler += this.OnAlter;
            this.OnAlter();
        }

        private void OnAlter() {
            this.adsButton.interactable = this.ads.IsLoaded;
        }

        public void Collect() {
            DIContainer.LoginRepository.Collect(false);
            this.closeButton.Close();
        }

        public void PlayAds() {
            this.ads.Play();
        }

        private void OnReward() {
            DIContainer.LoginRepository.Collect(true);
            this.closeButton.Close();
        }
    }
}
