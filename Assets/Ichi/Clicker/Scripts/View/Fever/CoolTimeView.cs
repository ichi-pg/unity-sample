using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Ichi.Clicker.View
{
    public class CoolTimeView : MonoBehaviour
    {
        [Inject]
        private IFeverRepository feverRepository;
        [SerializeField]
        private Text coolTime;
        [SerializeField]
        private Text adsCoolTime;

        void Start() {
            this.UpdateView(this.GetCancellationTokenOnDestroy()).Forget();
        }

        private async UniTask UpdateView(CancellationToken token) {
            while (true) {
                this.coolTime.text = this.feverRepository.CoolTime.ToString("mm\\:ss");
                this.adsCoolTime.text = this.feverRepository.AdsCoolTime.ToString("mm\\:ss");
                await UniTask.Delay(TimeSpan.FromSeconds(1), cancellationToken: token);
            }
        }
    }
}
