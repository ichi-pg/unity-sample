using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Ichi.Clicker.View
{
    public class LoginModal : MonoBehaviour
    {
        [Inject]
        private ILoginRepository loginRepository;
        [Inject]
        private Common.IAdsCreator adsCreator;
        [SerializeField]
        private Text quantity;
        [SerializeField]
        private Common.Gauge gauge;
        [SerializeField]
        private Button adsButton;
        [SerializeField]
        private Common.ModalCloser closer;

        private Common.IAds ads;

        void Start() {
            this.quantity.text = Common.BigIntegerText.ToString(this.loginRepository.Item.Quantity);
            this.gauge.Resize(this.loginRepository.QuantityRate);
            this.ads = this.adsCreator.Create();
            this.ads.RewardHandler += this.OnReward;
            this.ads.LoadHandler += this.OnLoadAds;
            this.OnLoadAds();
        }

        private void OnLoadAds() {
            this.adsButton.interactable = this.ads.IsLoaded;
        }

        public void Collect() {
            this.loginRepository.Collect(false);
            this.closer.Close();
        }

        public void PlayAds() {
            this.ads.Play();
        }

        private void OnReward() {
            this.loginRepository.Collect(true);
            this.closer.Close();
            //TODO エフェクト
            //TODO SE
        }
    }
}
