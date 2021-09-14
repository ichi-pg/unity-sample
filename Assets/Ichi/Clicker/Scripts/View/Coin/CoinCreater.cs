using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Numerics;
using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UniRx;

namespace Ichi.Clicker.View
{
    public class CoinCreater : MonoBehaviour
    {
        [SerializeField]
        private GameObject prefab;
        [SerializeField]
        private RectTransform target;
        private CancellationToken token;

        void Start() {
            this.token = this.GetCancellationTokenOnDestroy();
            DIContainer.CoinRepository.Item.OnAlter.Subscribe(this.OnAlter).AddTo(this);
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
            var obj = Common.AnimationCreater.Create(this.prefab, this.target);
            obj.GetComponent<CoinAnimation>().SetSprite(index);
        }
    }
}
