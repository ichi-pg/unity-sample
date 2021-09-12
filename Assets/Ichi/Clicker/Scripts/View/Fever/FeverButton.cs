using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Ichi.Clicker.View
{
    public class FeverButton : MonoBehaviour
    {
        [SerializeField]
        private Image gauge;
        [SerializeField]
        private Image gaugeParent;
        [SerializeField]
        private Button button;
        private CancellationToken token;

        void Start() {
            this.token = this.GetCancellationTokenOnDestroy();
            DIContainer.FeverRepository.AlterHandler += this.OnAlter;
            this.OnAlter();
            this.CoolTime().Forget();
        }

        void OnDestroy() {
            DIContainer.FeverRepository.AlterHandler -= this.OnAlter;
        }

        private void OnAlter() {
            this.button.interactable =
                !DIContainer.FeverRepository.IsCoolTime &&
                !DIContainer.FeverRepository.IsFever;
            Common.Gauge.ResizeY(
                this.gauge,
                this.gaugeParent,
                DIContainer.FeverRepository.DurationRate
            );
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
