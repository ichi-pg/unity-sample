using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using Zenject;

namespace Ichi.Clicker.View
{
    public class FeverAdsButton : MonoBehaviour
    {
        [Inject]
        private IFeverRepository feverRepository;
        [Inject]
        private Common.IAdsCreator adsCreator;
        [SerializeField]
        private Button button;
        private Common.IAds ads;
        private CancellationToken token;

        void Start() {
            this.token = this.GetCancellationTokenOnDestroy();
            this.ads = this.adsCreator.Create();
            this.ads.RewardHandler += this.OnReward;
            this.ads.LoadHandler += this.OnAlter;
            this.feverRepository.OnAlter.Subscribe(_ => this.OnAlter()).AddTo(this);
            this.OnAlter();
            this.CoolTime().Forget();
        }

        private void OnAlter() {
            this.button.interactable = this.ads.IsLoaded &&
                this.feverRepository.IsCoolTime &&
                !this.feverRepository.IsAdsCoolTime &&
                !this.feverRepository.IsFever;
        }

        public void PlayAds() {
            this.ads.Play();
        }

        private void OnReward() {
            this.feverRepository.CoolDown();
            this.CoolTime().Forget();
            //NOTE エフェクト
            //NOTE SE
        }

        private async UniTask CoolTime() {
            await UniTask.Delay(this.feverRepository.AdsCoolTime, cancellationToken: this.token);
            this.OnAlter();
        }
    }
}
