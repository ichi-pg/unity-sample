using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

namespace Ichi.Clicker
{
    [RequireComponent(typeof(Button))]
    public class FeverButton : MonoBehaviour
    {
        private Button button;
        private CancellationToken token;
        private IFeverRepository repository;

        void Start() {
            this.button = this.GetComponent<Button>();
            this.token = this.GetCancellationTokenOnDestroy();
            this.repository = DIContainer.FeverRepository;
            this.repository.AlterHandler += this.OnAlter;
            this.OnAlter();
            this.CoolTime().Forget();
        }

        void OnDestroy() {
            this.repository.AlterHandler -= this.OnAlter;
        }

        private void OnAlter() {
            this.button.interactable =
                this.repository.CoolTime <= TimeSpan.Zero &&
                this.repository.RemainDuration <= TimeSpan.Zero;
        }

        public void Fever() {
            this.Produce().Forget();
            this.CoolTime().Forget();
        }

        private async UniTask CoolTime() {
            await UniTask.Delay(this.repository.CoolTime, cancellationToken: this.token);
            this.OnAlter();
        }

        private async UniTask Produce() {
            do
            {
                this.repository.Produce();
                await UniTask.Delay(this.repository.Interval, cancellationToken: this.token);
            }
            while (this.repository.RemainDuration > TimeSpan.Zero);
            this.OnAlter();
        }
    }
}
