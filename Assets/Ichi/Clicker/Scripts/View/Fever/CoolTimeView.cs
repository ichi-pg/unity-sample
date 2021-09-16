using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Ichi.Clicker.View
{
    public class CoolTimeView : MonoBehaviour
    {
        [SerializeField]
        private Text coolTime;
        [SerializeField]
        private Text adsCoolTime;

        void Start() {
            this.UpdateView(this.GetCancellationTokenOnDestroy()).Forget();
        }

        private async UniTask UpdateView(CancellationToken token) {
            while (true) {
                this.coolTime.text = DIContainer.FeverRepository.CoolTime.ToString("mm\\:ss");
                this.adsCoolTime.text = DIContainer.CoolDownRepository.CoolTime.ToString("mm\\:ss");
                await UniTask.Delay(TimeSpan.FromSeconds(1), cancellationToken: token);
            }
        }
    }
}
