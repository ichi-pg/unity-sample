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
                    TimeSpan.FromSeconds(30),
                    cancellationToken: this.GetCancellationTokenOnDestroy()
                );
                button.interactable = true;
            } catch(OperationCanceledException) {
            } finally {
                token.Cancel();
            }
            //TODO 広告でフィーバー回復
        }

        public async UniTask FeverProduce(CancellationToken token) {
            while (true)
            {
                var repository = Dependency.FactoryRepository;
                foreach (var factory in repository.ClickFactories) {
                    if (!factory.IsLocked) {
                        repository.FeverProduce(factory);
                    }
                }
                Ichi.Common.DataInjector.Modify();
                await UniTask.Delay(TimeSpan.FromMilliseconds(100), cancellationToken: token);
            }
        }
    }
}
