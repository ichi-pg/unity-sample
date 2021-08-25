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
            this.AutoProduce(token.Token).Forget();
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
            //TODO フィーバーレベル
        }

        public async UniTask AutoProduce(CancellationToken token) {
            while (true)
            {
                foreach (var produceButton in this.transform.root.GetComponentsInChildren<ProduceButton>()) {
                    produceButton.Produce();
                }
                await UniTask.Delay(TimeSpan.FromMilliseconds(100), cancellationToken: token);
            }
        }
    }
}
