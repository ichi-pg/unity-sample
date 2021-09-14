using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Ichi.Common
{
    public class WaitTapButton : MonoBehaviour
    {
        private bool isTap;

        public async UniTask Wait(CancellationToken token) {
            this.isTap = false;
            await UniTask.WaitUntil(() => this.isTap, cancellationToken: token);
        }

        public void Tap() {
            this.isTap = true;
        }
    }
}
