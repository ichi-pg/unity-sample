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
        async void Start() {
            if (DIContainer.FeverRepository.CoolTime > TimeSpan.Zero) {
                await this.CoolTime();
            }
        }

        public async void Fever() {
            var button = this.GetComponent<Button>();
            button.interactable = false;
            var token = new CancellationTokenSource();
            this.Produce(token.Token).Forget();
            try {
                await UniTask.Delay(
                    DIContainer.FeverRepository.Duration,
                    cancellationToken: this.GetCancellationTokenOnDestroy()
                );
            } catch(OperationCanceledException) {
            } finally {
                token.Cancel();
            }
            await this.CoolTime();
        }

        private async UniTask CoolTime() {
            var button = this.GetComponent<Button>();
            button.interactable = false;
            try {
                await UniTask.Delay(
                    DIContainer.FeverRepository.CoolTime,
                    cancellationToken: this.GetCancellationTokenOnDestroy()
                );
                button.interactable = true;
            } catch(OperationCanceledException) {
            }
        }

        public async UniTask Produce(CancellationToken token) {
            while (true)
            {
                DIContainer.FeverRepository.Produce();
                Ichi.Common.DataInjector.Modify();
                await UniTask.Delay(
                    DIContainer.FeverRepository.Interval,
                    cancellationToken: token
                );
            }
        }
    }
}
