using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Ichi.Clicker.View
{
    public class AutoProducer : MonoBehaviour
    {
        [Inject]
        private ILoginRepository loginRepository;
        [Inject]
        private IFactoryRepository factoryRepository;
        [SerializeField]
        private Common.ModalOpener loginModalOpener;

        void Start() {
            if (this.loginRepository.Produce()) {
                this.loginModalOpener.Open();
            }
            this.Produce(this.GetCancellationTokenOnDestroy()).Forget();
        }

        private async UniTask Produce(CancellationToken token) {
            while (true) {
                this.factoryRepository.Produce();
                await UniTask.Delay(TimeSpan.FromSeconds(1), cancellationToken: token);
            }
        }
    }
}
