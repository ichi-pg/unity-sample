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
        public Button button;

        void Start() {
            DIContainer.FeverRepository.OnAlter.Subscribe(_ => this.OnAlter()).AddTo(this);
            DIContainer.CoolDownRepository.OnAlter.Subscribe(_ => this.OnAlter()).AddTo(this);
            this.button.OnClickAsObservable().Subscribe(_ => this.Fever()).AddTo(this);
            this.OnAlter();
        }

        private void OnAlter() {
            this.button.interactable =
                DIContainer.FeverRepository.CoolTime <= TimeSpan.Zero &&
                DIContainer.FeverRepository.TimeLeft <= TimeSpan.Zero;
        }

        public void Fever() {
            DIContainer.FeverRepository.Fever();
            //TODO エフェクト
            //TODO SE
        }
    }
}
