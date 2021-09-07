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
                var count = diff.ToString().Length;
                for (var i = 0; i < count; ++i) {
                    this.CreateTask().Forget();
                }
            }
            this.beforeQuantity = quantity;
        }

        private async UniTask CreateTask() {
            await UniTask.Delay(
                TimeSpan.FromMilliseconds((double)UnityEngine.Random.Range(0, 500)),
                cancellationToken: this.token
            );
            this.animationCreater.Create();
        }
    }
}
