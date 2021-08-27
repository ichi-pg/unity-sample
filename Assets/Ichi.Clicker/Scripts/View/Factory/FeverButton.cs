using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Ichi.Clicker
{
    [RequireComponent(typeof(Button))]
    public class FeverButton : MonoBehaviour
    {
        public async void Fever() {
            var button = this.GetComponent<Button>();
            button.interactable = false;
            var token = new CancellationTokenSource();
            this.FeverProduce(token.Token).Forget();
            try {
                await UniTask.Delay(
                    DIContainer.FactoryRepository.FeverSpan,
                    cancellationToken: this.GetCancellationTokenOnDestroy()
                );
                button.interactable = true;
            } catch(OperationCanceledException) {
            } finally {
                token.Cancel();
            }
        }

        public async UniTask FeverProduce(CancellationToken token) {
            while (true)
            {
                DIContainer.FactoryRepository.FeverProduce();
                Ichi.Common.DataInjector.Modify();
                await UniTask.Delay(
                    DIContainer.FactoryRepository.FeverInterval,
                    cancellationToken: token
                );
            }
        }
    }
}
