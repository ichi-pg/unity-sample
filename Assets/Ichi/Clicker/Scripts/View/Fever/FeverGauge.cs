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
            var now = DIContainer.TimeRepository.Now;
            var fever = DIContainer.SkillRepository.GetSkill(SkillCategory.Fever);
            this.gauge.Resize((float)fever.TimeLeft(now).Ticks / fever.MaxTimeLeft.Ticks);
        }
    }
}

