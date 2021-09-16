using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

namespace Ichi.Clicker.View
{
    public class FeverButton : MonoBehaviour
    {
        [SerializeField]
        private Button button;
        [SerializeField]
        private Common.Gauge gauge;

        void Start() {
            DIContainer.FeverRepository.OnAlter.Subscribe(_ => this.OnAlter()).AddTo(this);
            DIContainer.CoolDownRepository.OnAlter.Subscribe(_ => this.OnAlter()).AddTo(this);
            this.OnAlter();
        }

        private void OnAlter() {
            this.button.interactable =
                DIContainer.FeverRepository.CoolTime <= TimeSpan.Zero &&
                DIContainer.FeverRepository.TimeLeft <= TimeSpan.Zero;
            this.gauge.Resize((float)DIContainer.FeverRepository.TimeLeft.Ticks / DIContainer.FeverRepository.Duration.Ticks);
        }

        public void Fever() {
            DIContainer.FeverRepository.Fever();
            //TODO エフェクト
            //TODO SE
        }
    }
}
