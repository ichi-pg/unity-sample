using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Numerics;
using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Ichi.Clicker.View
{
    public class CoinCreater : MonoBehaviour
    {
        [SerializeField]
        private GameObject coin;
        [SerializeField]
        private RectTransform region;
        private CancellationToken token;
        private BigInteger beforeQuantity;

        void Start() {
            this.token = this.GetCancellationTokenOnDestroy();
            this.beforeQuantity = DIContainer.CoinRepository.Item.Quantity;
            DIContainer.CoinRepository.Item.AlterHandler += this.OnAlter;
        }

        void OnDestroy() {
            DIContainer.CoinRepository.Item.AlterHandler -= this.OnAlter;
        }

        private void OnAlter() {
            var quantity = DIContainer.CoinRepository.Item.Quantity;
            var diff = quantity - beforeQuantity;
            if (diff > 0) {
                var count = diff.ToString().Length / 3 + 1;
                var index = (int)Math.Min((count - 1) / 3, 2);
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
            var obj = Common.AnimationCreater.Create(this.coin, this.region);
            obj.GetComponent<CoinAnimation>().SetSprite(index);
        }
    }
}
