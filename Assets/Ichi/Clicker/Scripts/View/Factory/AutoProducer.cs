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
            if (DIContainer.LoginRepository.Quanity > 0) {
                this.GetComponent<Common.OpenModalButton>().Open();
            }
            this.AutoProduce(this.GetCancellationTokenOnDestroy()).Forget();
        }

        private async UniTask AutoProduce(CancellationToken token) {
            while (true)
            {
                var repository = DIContainer.FactoryRepository;
                foreach (var factory in repository.AutoFactories) {
                    if (factory.IsBought) {
                        repository.Produce(factory);
                    }
                }
                Ichi.Common.DataInjector.Modify();
                await UniTask.Delay(TimeSpan.FromSeconds(1), cancellationToken: token);
            }
        }
    }
}
