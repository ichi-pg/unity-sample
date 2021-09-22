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

        public bool IsInteractable {
            get {
                var now = DIContainer.TimeRepository.Now;
                var fever = DIContainer.SkillRepository.GetSkill(SkillCategory.Fever);
                return fever.TimeLeft(now) <= TimeSpan.Zero &&
                    fever.CoolTime(now) <= TimeSpan.Zero;
            }
        }

        void Start() {
            DIContainer.FeverRepository.OnAlter.Subscribe(_ => this.OnAlter()).AddTo(this);
            DIContainer.CoolDownRepository.OnAlter.Subscribe(_ => this.OnAlter()).AddTo(this);
            this.button.OnClickAsObservable().Subscribe(_ => this.Fever()).AddTo(this);
            this.OnAlter();
        }

        private void OnAlter() {
            this.button.interactable = this.IsInteractable;
        }

        private void Fever() {
            DIContainer.FeverRepository.Fever();
            //TODO 発動エフェクト
            //TODO 発動中、画面全体エフェクト
            //TODO SE
        }
    }
}
