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
        private SkillCategory category;

        void Start() {
            this.UpdateView().Forget();
        }

        private async UniTask UpdateView() {
            var token = this.GetCancellationTokenOnDestroy();
            while (true) {
                var skill = DIContainer.SkillRepository.GetSkill(this.category);
                var rate = skill.CoolTimeRate();
                this.gauge.fillAmount = rate;
                this.gameObject.SetActive(rate > 0f);
                await UniTask.Delay(TimeSpan.FromMilliseconds(100), cancellationToken: token);
                //TODO 発動中とクールダウンの見た目変えないと分からない
            }
        }

        public void SetCategory(SkillCategory category) {
            this.category = category;
        }
    }
}
