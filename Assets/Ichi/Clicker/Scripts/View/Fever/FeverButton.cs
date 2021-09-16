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
                !DIContainer.FeverRepository.IsCoolTime &&
                !DIContainer.FeverRepository.IsFever;
            this.gauge.Resize(DIContainer.FeverRepository.TimeLeftRate);
        }

        public void Fever() {
            DIContainer.FeverRepository.Fever();
            //TODO エフェクト
            //TODO SE
        }
    }
}
