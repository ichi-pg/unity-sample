using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using Zenject;

namespace Ichi.Clicker.View
{
    public class FeverButton : MonoBehaviour
    {
        [Inject]
        private IFeverRepository feverRepository;
        [SerializeField]
        private Button button;
        [SerializeField]
        private Common.Gauge gauge;
        private CancellationToken token;

        void Start() {
            this.token = this.GetCancellationTokenOnDestroy();
            this.feverRepository.OnAlter.Subscribe(_ => this.OnAlter()).AddTo(this);
            this.OnAlter();
            this.CoolTime().Forget();
        }

        private void OnAlter() {
            this.button.interactable =
                !this.feverRepository.IsCoolTime &&
                !this.feverRepository.IsFever;
            this.gauge.Resize(this.feverRepository.DurationRate);
        }

        public void Fever() {
            this.feverRepository.Fever(this.token);
            this.UpdateGauge().Forget();
            this.CoolTime().Forget();
            //TODO エフェクト
            //TODO SE
        }

        private async UniTask UpdateGauge() {
            while (this.feverRepository.IsFever)
            {
                this.OnAlter();
                await UniTask.Delay(TimeSpan.FromMilliseconds(100), cancellationToken: this.token);
            }
        }

        private async UniTask CoolTime() {
            await UniTask.Delay(this.feverRepository.CoolTime, cancellationToken: this.token);
            this.OnAlter();
        }
    }
}
