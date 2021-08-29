using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Ichi.Clicker
{
    [RequireComponent(typeof(Button))]
    public class FeverButton : MonoBehaviour
    {
        private Button button;
        private CancellationToken token;

        void Start() {
            this.button = this.GetComponent<Button>();
            this.token = this.GetCancellationTokenOnDestroy();
            DIContainer.FeverRepository.AlterHandler += this.OnAlter;
            this.OnAlter();
            this.CoolTime().Forget();
        }

        void OnDestroy() {
            DIContainer.FeverRepository.AlterHandler -= this.OnAlter;
        }

        private void OnAlter() {
            this.button.interactable =
                !DIContainer.FeverRepository.IsCoolTime &&
                !DIContainer.FeverRepository.IsFever;
        }

        public void Fever() {
            DIContainer.FeverRepository.Fever(this.token);
            this.CoolTime().Forget();
        }

        private async UniTask CoolTime() {
            await UniTask.Delay(DIContainer.FeverRepository.CoolTime, cancellationToken: this.token);
            this.OnAlter();
        }
    }
}
