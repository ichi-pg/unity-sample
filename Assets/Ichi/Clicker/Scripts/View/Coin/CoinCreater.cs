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

        void Start() {
            this.token = this.GetCancellationTokenOnDestroy();
            this.animationCreater = this.GetComponent<Common.AnimationCreater>();
            this.CreateLoop().Forget();
        }

        private async UniTask CreateLoop() {
            while (true)
            {
                //TODO 使った分が計上されないので、正確に増えた分を通知で受け取りたい
                var beforeQuantity = DIContainer.CoinRepository.Coin.Quantity;
                await UniTask.Delay(TimeSpan.FromMilliseconds(100), cancellationToken: this.token);
                var quantity = DIContainer.CoinRepository.Coin.Quantity;
                var diff = quantity - beforeQuantity;
                if (diff > 0) {
                    var count = diff.ToString().Length;
                    for (var i = 0; i < count; ++i) {
                        this.CreateTask().Forget();
                    }
                }
            }
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
