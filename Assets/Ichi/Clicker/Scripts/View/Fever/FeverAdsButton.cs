using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Ichi.Clicker.View
{
    [RequireComponent(typeof(Button))]
    public class FeverAdsButton : MonoBehaviour
    {
        private Button button;
        private Common.IAds ads;
        private CancellationToken token;

        void Start() {
            this.button = this.GetComponent<Button>();
            this.token = this.GetCancellationTokenOnDestroy();
            this.ads = DIContainer.AdsCreator.Create();
            this.ads.RewardHandler += this.OnReward;
            this.ads.LoadHandler += this.OnAlter;
            DIContainer.FeverRepository.AlterHandler += this.OnAlter;
            this.OnAlter();
            this.CoolTime().Forget();
        }

        void OnDestroy() {
            DIContainer.FeverRepository.AlterHandler -= this.OnAlter;
        }

        private void OnAlter() {
            this.button.interactable = this.ads.IsLoaded &&
                DIContainer.FeverRepository.IsCoolTime &&
                !DIContainer.FeverRepository.IsAdsCoolTime &&
                !DIContainer.FeverRepository.IsFever;
        }

        public void PlayAds() {
            this.ads.Play();
        }

        private void OnReward() {
            DIContainer.FeverRepository.CoolDown();
            this.CoolTime().Forget();
        }

        private async UniTask CoolTime() {
            await UniTask.Delay(DIContainer.FeverRepository.AdsCoolTime, cancellationToken: this.token);
            this.OnAlter();
        }
    }
}
