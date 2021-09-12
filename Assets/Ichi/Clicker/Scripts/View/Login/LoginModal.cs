using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Ichi.Clicker.View
{
    public class LoginModal : MonoBehaviour
    {
        [SerializeField]
        private Text quantity;
        [SerializeField]
        private Image gauge;
        [SerializeField]
        private Image gaugeParent;
        [SerializeField]
        private Button adsButton;
        [SerializeField]
        private Common.CloseModalButton closeModalButton;

        private Common.IAds ads;

        void Start() {
            this.quantity.text = Common.BigIntegerText.ToString(DIContainer.LoginRepository.Quantity);
            Common.Gauge.ResizeX(
                this.gauge,
                this.gaugeParent,
                DIContainer.LoginRepository.QuantityRate
            );
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
            this.closeModalButton.Close();
        }

        public void PlayAds() {
            this.ads.Play();
        }

        private void OnReward() {
            DIContainer.LoginRepository.Collect(true);
            this.closeModalButton.Close();
        }
    }
}
