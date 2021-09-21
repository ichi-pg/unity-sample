using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

namespace Ichi.Clicker.View
{
    public class FeverGauge : MonoBehaviour
    {
        [SerializeField]
        private Common.Gauge gauge;

        void Start() {
            DIContainer.FeverRepository.OnAlter.Subscribe(_ => this.OnAlter()).AddTo(this);
            DIContainer.FeverRepository.OnProduce.Subscribe(_ => this.OnAlter()).AddTo(this);
            DIContainer.CoolDownRepository.OnAlter.Subscribe(_ => this.OnAlter()).AddTo(this);
        }

        private void OnAlter() {
            this.gauge.Resize((float)DIContainer.FeverRepository.TimeLeft.Ticks / DIContainer.FeverRepository.MaxTimeLeft.Ticks);
        }
    }
}

