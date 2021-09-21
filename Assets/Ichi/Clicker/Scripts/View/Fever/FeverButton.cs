using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

namespace Ichi.Clicker.View
{
    public class FeverButton : MonoBehaviour, ISkillButton
    {
        [SerializeField]
        private Button button;

        public bool IsActive { get => DIContainer.FeverRepository.TimeLeft > TimeSpan.Zero; }

        void Start() {
            DIContainer.FeverRepository.OnAlter.Subscribe(_ => this.OnAlter()).AddTo(this);
            DIContainer.CoolDownRepository.OnAlter.Subscribe(_ => this.OnAlter()).AddTo(this);
            this.button.OnClickAsObservable().Subscribe(_ => this.Fever()).AddTo(this);
            this.OnAlter();
        }

        private void OnAlter() {
            this.button.interactable = !this.IsActive &&
                DIContainer.FeverRepository.CoolTime <= TimeSpan.Zero;
        }

        private void Fever() {
            DIContainer.FeverRepository.Fever();
            //TODO エフェクト
            //TODO SE
        }

        public void SetButton(Button button) {
            this.button = button;
        }
    }
}
