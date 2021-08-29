using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Ichi.Clicker
{
    public class LoginModal : MonoBehaviour
    {
        [SerializeField]
        private Text quantity;
        [SerializeField]
        private Text percentage;

        private Common.IAds ads;

        void Start() {
            this.quantity.text = Common.BigIntegerText.ToString(DIContainer.LoginRepository.Quantity);
            this.percentage.text = DIContainer.LoginRepository.Percentage+"%";
            this.ads = DIContainer.AdsCreator.Create();
            this.ads.RewardHandler += this.OnReward;
        }

        public void Collect() {
            DIContainer.LoginRepository.Collect(false);
        }

        public void PlayAds() {
            this.ads.Play();
            //TODO ロード完了までボタン非活性
        }

        private void OnReward() {
            DIContainer.LoginRepository.Collect(true);
            //TODO キャンセルした場合、普通に受け取れる
        }
    }
}
