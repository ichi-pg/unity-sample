
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Ichi.Common
{
    public class DelayCanceler : MonoBehaviour
    {
        private CancellationTokenSource tokenSource;

        public async UniTask Execute(Action action, TimeSpan delay) {
            this.tokenSource?.Cancel();
            this.tokenSource = new CancellationTokenSource();
            await UniTask.Delay(delay, cancellationToken: this.tokenSource.Token);
            action();
        }

        void OnDestroy() {
            this.tokenSource?.Cancel();
        }
    }
}
