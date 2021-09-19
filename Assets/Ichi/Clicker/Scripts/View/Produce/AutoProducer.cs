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
        private Common.ModalOpener loginModalOpener;

        void Start() {
            if (DIContainer.LoginRepository.Produce()) {
                this.loginModalOpener.Open();
            }
            this.Produce().Forget();
        }

        private async UniTask Produce() {
            var token = this.GetCancellationTokenOnDestroy();
            while (true) {
                DIContainer.FactoryRepository.Produce();
                await UniTask.Delay(TimeSpan.FromSeconds(1), cancellationToken: token);
            }
        }
    }
}
