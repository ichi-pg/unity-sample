using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

namespace Ichi.Clicker
{
    [RequireComponent(typeof(Button))]
    public class FeverButton : MonoBehaviour
    {
        private Button button;
        private CancellationToken token;

        async void Start() {
            this.button = this.GetComponent<Button>();
            this.token = this.GetCancellationTokenOnDestroy();
            DIContainer.FeverRepository.AlterHandler += this.OnAlter;
            this.OnAlter();
            try {
                await UniTask.Delay(DIContainer.FeverRepository.CoolTime, cancellationToken: this.token);
                this.OnAlter();
            } catch(OperationCanceledException) {
            }
        }

        void OnDestroy() {
            DIContainer.FeverRepository.AlterHandler -= this.OnAlter;
        }

        private void OnAlter() {
            this.button.interactable =
                DIContainer.FeverRepository.CoolTime <= TimeSpan.Zero &&
                DIContainer.FeverRepository.RemainDuration <= TimeSpan.Zero;
        }

        public async void Fever() {
            var loop = new CancellationTokenSource();
            this.Produce(loop.Token).Forget();
            try {
                await UniTask.Delay(DIContainer.FeverRepository.Duration, cancellationToken: this.token);
                this.OnAlter();
                loop.Cancel();//TODO DurationのタイミングでCoolTimeがないと連続実行される
                await UniTask.Delay(DIContainer.FeverRepository.CoolTime, cancellationToken: this.token);
                this.OnAlter();
            } catch(OperationCanceledException) {
                loop.Cancel();
            }
        }

        public async UniTask Produce(CancellationToken cancelToken) {
            while (true)
            {
                DIContainer.FeverRepository.Produce();
                await UniTask.Delay(DIContainer.FeverRepository.Interval, cancellationToken: cancelToken);
            }
        }
    }
}
