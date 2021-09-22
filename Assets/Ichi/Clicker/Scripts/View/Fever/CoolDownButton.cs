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

        public bool IsInteractable {
            get {
                var now = DIContainer.TimeRepository.Now;
                var fever = DIContainer.SkillRepository.GetSkill(SkillCategory.Fever);
                var coolDown = DIContainer.SkillRepository.GetSkill(SkillCategory.CoolDown);
                return fever.CoolTime(now) > TimeSpan.Zero &&
                    coolDown.CoolTime(now) <= TimeSpan.Zero &&
                    fever.TimeLeft(now) <= TimeSpan.Zero;
            }
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
