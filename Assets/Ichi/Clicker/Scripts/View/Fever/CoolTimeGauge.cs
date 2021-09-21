using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Ichi.Clicker.View
{
    public class CoolTimeGauge : MonoBehaviour
    {
        [SerializeField]
        private Image gauge;
        [SerializeField]
        private Image background;
        [SerializeField]
        private SkillCategory category;

        private Skill skill;
        private Color gaugeColor;
        private Color backgroundColor;

        void Start() {
            this.gaugeColor = this.gauge.color;
            this.backgroundColor = this.background.color;
            this.SetCategory(this.category);
            this.UpdateView().Forget();
        }

        private async UniTask UpdateView() {
            var token = this.GetCancellationTokenOnDestroy();
            while (true) {
                var rate = this.skill.CoolTimeRate();
                var isWork = skill.IsWork();
                this.gauge.fillAmount = rate;
                this.gameObject.SetActive(rate > 0f);
                this.gauge.color = isWork ? this.gaugeColor : new Color(0f, 0f, 0f, this.gaugeColor.a);
                this.background.color = isWork ? this.backgroundColor : new Color(0f, 0f, 0f, this.backgroundColor.a);
                await UniTask.Delay(TimeSpan.FromMilliseconds(100), cancellationToken: token);
            }
        }

        public void SetCategory(SkillCategory category) {
            this.category = category;
            this.skill = DIContainer.SkillRepository.GetSkill(this.category);
        }
    }
}
