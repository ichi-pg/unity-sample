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

        public float WorkRate { get => 0f; }
        public bool IsInteractable {
            get =>
                DIContainer.FeverRepository.CoolTime > TimeSpan.Zero &&
                DIContainer.CoolDownRepository.CoolTime <= TimeSpan.Zero &&
                DIContainer.FeverRepository.TimeLeft <= TimeSpan.Zero;
        }

        void Start() {
            DIContainer.FeverRepository.OnAlter.Subscribe(_ => this.OnAlter()).AddTo(this);
            DIContainer.CoolDownRepository.OnAlter.Subscribe(_ => this.OnAlter()).AddTo(this);
            this.button.OnClickAsObservable().Subscribe(_ => this.OpenModal()).AddTo(this);
            this.OnAlter();
        }

        private void OnAlter() {
            this.button.interactable = this.IsInteractable;
        }

        private void OpenModal() {
            this.modalOpener.Open();
        }
    }
}
