using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

namespace Ichi.Clicker.View
{
    public class CoolDownButton : MonoBehaviour, ISkillButton
    {
        [SerializeField]
        private Button button;
        [SerializeField]
        private Common.ModalOpener modalOpener;

        void Start() {
            DIContainer.FeverRepository.OnAlter.Subscribe(_ => this.OnAlter()).AddTo(this);
            DIContainer.CoolDownRepository.OnAlter.Subscribe(_ => this.OnAlter()).AddTo(this);
            this.button.OnClickAsObservable().Subscribe(_ => this.OpenModal()).AddTo(this);
            this.OnAlter();
        }

        private void OnAlter() {
            this.button.interactable =
                DIContainer.FeverRepository.CoolTime > TimeSpan.Zero &&
                DIContainer.CoolDownRepository.CoolTime <= TimeSpan.Zero &&
                DIContainer.FeverRepository.TimeLeft <= TimeSpan.Zero;
        }

        private void OpenModal() {
            this.modalOpener.Open();
        }

        public void SetButton(Button button) {
            this.button = button;
        }
    }
}
