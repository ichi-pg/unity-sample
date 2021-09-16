using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

namespace Ichi.Clicker.View
{
    public class FeverAdsButton : MonoBehaviour
    {
        [SerializeField]
        private Button button;
        private Common.IAds ads;
        private CancellationToken token;

        void Start() {
            this.token = this.GetCancellationTokenOnDestroy();
            this.ads = DIContainer.AdsCreator.Create();
            this.ads.RewardHandler += this.OnReward;
            this.ads.LoadHandler += this.OnAlter;
            DIContainer.FeverRepository.OnAlter.Subscribe(_ => this.OnAlter()).AddTo(this);
            this.OnAlter();
            this.CoolTime().Forget();
        }

        private void OnAlter() {
            this.button.interactable = this.ads.IsLoaded &&
                DIContainer.FeverRepository.IsCoolTime &&
                !DIContainer.CoolDownRepository.IsCoolTime &&
                !DIContainer.FeverRepository.IsFever;
        }

        public void PlayAds() {
            this.ads.Play();
        }

        private void OnReward() {
            DIContainer.CoolDownRepository.CoolDown();
            this.CoolTime().Forget();
            //TODO エフェクト
            //TODO SE
        }

        private async UniTask CoolTime() {
            await UniTask.Delay(DIContainer.CoolDownRepository.CoolTime, cancellationToken: this.token);
            this.OnAlter();
        }
    }
}
