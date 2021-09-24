using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Numerics;
using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UniRx;
using Random = UnityEngine.Random;

namespace Ichi.Clicker.View
{
    public class CoinGenerator : MonoBehaviour
    {
        [SerializeField]
        private Common.RandomGenerator generater;
        private CancellationToken token;

        void Start() {
            this.token = this.GetCancellationTokenOnDestroy();
            DIContainer.ItemRepository.GetItem(ItemCategory.Coin).OnAlter.Subscribe(this.OnAlter).AddTo(this);
        }

        private void OnAlter(BigInteger diff) {
            if (diff > 0) {
                var index = (int)Common.Math.Min(diff / 1000, 2);
                this.CreateTask(index).Forget();
                //NOTE 全額をまとめて1000で割った個数でゴールドをばら撒く？
            }
        }

        private async UniTask CreateTask(int index) {
            await UniTask.Delay(
                TimeSpan.FromMilliseconds((double)Random.Range(0, 500)),
                cancellationToken: this.token
            );
            this.generater.Generate<CoinAnimation>().Play(index);
        }
    }
}
