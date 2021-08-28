using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Ichi.Clicker
{
    [RequireComponent(typeof(Common.OpenModalButton))]
    public class AutoProducer : MonoBehaviour
    {
        void Start() {
            DIContainer.LoginRepository.Produce();
            if (DIContainer.LoginRepository.Quantity > 0) {
                this.GetComponent<Common.OpenModalButton>().Open();
            }
            this.Produce(this.GetCancellationTokenOnDestroy()).Forget();
        }

        private async UniTask Produce(CancellationToken token) {
            while (true)
            {
                var repository = DIContainer.FactoryRepository;
                foreach (var factory in repository.AutoFactories) {
                    if (factory.IsBought) {
                        repository.Produce(factory);
                    }
                }
                Common.DataInjector.Modify();
                await UniTask.Delay(TimeSpan.FromSeconds(1), cancellationToken: token);
            }
        }
    }
}
