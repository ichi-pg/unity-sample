using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Threading;
using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UniRx;

namespace Ichi.Clicker.View
{
    public class EXPGenerator : MonoBehaviour
    {
        [SerializeField]
        private Common.PointGenerator generater;
        [SerializeField]
        private Transform target;

        void Start() {
            DIContainer.EnemyRepository.OnWin.Subscribe(this.OnWin).AddTo(this);
        }

        private void OnWin(IEnemy enemy) {
            this.Generate().Forget();
        }

        private async UniTask Generate() {
            var token = this.GetCancellationTokenOnDestroy();
            for (var i = 0; i < 10; ++i) {
                this.generater.Generate<EXPAnimation>().Play(this.target);
                await UniTask.Delay(TimeSpan.FromMilliseconds(20), cancellationToken: token);
            }
        }
    }
}
