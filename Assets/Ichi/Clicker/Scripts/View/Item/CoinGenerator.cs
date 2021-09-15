using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Numerics;
using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UniRx;
using Zenject;

namespace Ichi.Clicker.View
{
    public class CoinGenerator : MonoBehaviour
    {
        [Inject]
        private IFactoryRepository factoryRepository;
        [SerializeField]
        private Common.RandomGenerator generater;
        private CancellationToken token;

        void Start() {
            this.token = this.GetCancellationTokenOnDestroy();
            this.factoryRepository.OnProduce.Subscribe(this.OnAlter).AddTo(this);
        }

        private void OnAlter(BigInteger diff) {
            if (diff > 0) {
                var count = diff.ToString().Length / 3 + 1;
                var index = (int)Math.Min((count - 1) / 3, 2);
                count -= index * 3;
                for (var i = 0; i < count; ++i) {
                    this.CreateTask(index).Forget();
                }
            }
            //TODO レベルに合わせた頻度再調整
        }

        private async UniTask CreateTask(int index) {
            await UniTask.Delay(
                TimeSpan.FromMilliseconds((double)UnityEngine.Random.Range(0, 500)),
                cancellationToken: this.token
            );
            this.generater.Generate().GetComponent<CoinAnimation>().SetSprite(index);
        }
    }
}
