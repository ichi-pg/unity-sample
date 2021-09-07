using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Numerics;
using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Ichi.Clicker
{
    [RequireComponent(typeof(Common.AnimationCreater))]
    public class CoinCreater : MonoBehaviour
    {
        private Common.AnimationCreater animationCreater;
        private CancellationToken token;
        private BigInteger beforeQuantity;

        void Start() {
            this.token = this.GetCancellationTokenOnDestroy();
            this.animationCreater = this.GetComponent<Common.AnimationCreater>();
            this.beforeQuantity = DIContainer.CoinRepository.Coin.Quantity;
            DIContainer.CoinRepository.Coin.AlterHandler += this.OnAlter;
        }

        void OnDestroy() {
            DIContainer.CoinRepository.Coin.AlterHandler -= this.OnAlter;
        }

        private void OnAlter() {
            var quantity = DIContainer.CoinRepository.Coin.Quantity;
            var diff = quantity - beforeQuantity;
            if (diff > 0) {
                //TODO もうちょい調整。あとDOTweenのMAXまで到達してしまった。
                var count = diff.ToString().Length / 3 + 1;
                var index = Math.Min((count - 1) / 3, 2);
                count -= index * 3;
                for (var i = 0; i < count; ++i) {
                    this.CreateTask(index).Forget();
                }
            }
            this.beforeQuantity = quantity;
        }

        private async UniTask CreateTask(int index) {
            await UniTask.Delay(
                TimeSpan.FromMilliseconds((double)UnityEngine.Random.Range(0, 500)),
                cancellationToken: this.token
            );
            this.animationCreater.Create(index);
        }
    }
}
