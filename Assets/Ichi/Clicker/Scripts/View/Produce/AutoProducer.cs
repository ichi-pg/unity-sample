using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Ichi.Clicker.View
{
    public class AutoProducer : MonoBehaviour
    {
        [SerializeField]
        private Common.OpenModalButton openModalButton;

        void Start() {
            DIContainer.LoginRepository.Produce();
            if (DIContainer.LoginRepository.Quantity > 0) {
                this.openModalButton.Open();
            }
            this.Produce(this.GetCancellationTokenOnDestroy()).Forget();
        }

        private async UniTask Produce(CancellationToken token) {
            while (true) {
                DIContainer.FactoryRepository.Produce();
                await UniTask.Delay(TimeSpan.FromSeconds(1), cancellationToken: token);
            }
        }
    }
}
