using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

namespace Ichi.Clicker.View
{
    public class FeverButton : MonoBehaviour
    {
        [SerializeField]
        private Button button;
        [SerializeField]
        private Common.Gauge gauge;
        private CancellationToken token;

        void Start() {
            this.token = this.GetCancellationTokenOnDestroy();
            DIContainer.FeverRepository.OnAlter.Subscribe(_ => this.OnAlter()).AddTo(this);
            this.OnAlter();
            this.CoolTime().Forget();
        }

        private void OnAlter() {
            this.button.interactable =
                !DIContainer.FeverRepository.IsCoolTime &&
                !DIContainer.FeverRepository.IsFever;
            this.gauge.Resize(DIContainer.FeverRepository.DurationRate);
        }

        public void Fever() {
            DIContainer.FeverRepository.Fever(this.token);
            this.UpdateGauge().Forget();
            this.CoolTime().Forget();
            //エフェクト
            //SE
        }

        private async UniTask UpdateGauge() {
            while (DIContainer.FeverRepository.IsFever)
            {
                this.OnAlter();
                await UniTask.Delay(TimeSpan.FromMilliseconds(100), cancellationToken: this.token);
            }
        }

        private async UniTask CoolTime() {
            await UniTask.Delay(DIContainer.FeverRepository.CoolTime, cancellationToken: this.token);
            this.OnAlter();
        }
    }
}
