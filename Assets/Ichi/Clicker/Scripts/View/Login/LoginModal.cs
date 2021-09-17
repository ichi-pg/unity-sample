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
        private Common.Gauge gauge;
        [SerializeField]
        private Button adsButton;
        [SerializeField]
        private Common.ModalCloser closer;

        private Common.IAds ads;

        void Start() {
            var item = DIContainer.ItemRepository.GetItem(ItemCategory.Login);
            this.quantity.text = Common.Texts.ToString(item.Quantity);
            this.gauge.Resize(DIContainer.LoginRepository.Rate);
            this.ads = DIContainer.AdsCreator.Create();
            this.ads.RewardHandler += this.OnReward;
            this.ads.LoadHandler += this.OnLoadAds;
            this.OnLoadAds();
        }

        private void OnLoadAds() {
            this.adsButton.interactable = this.ads.IsLoaded;
        }

        public void Collect() {
            DIContainer.LoginRepository.Collect(false);
            this.closer.Close();
        }

        public void PlayAds() {
            this.ads.Play();
        }

        private void OnReward() {
            DIContainer.LoginRepository.Collect(true);
            this.closer.Close();
            //TODO エフェクト
            //TODO SE
        }
    }
}
