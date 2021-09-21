using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Ichi.Clicker.View
{
    public class CoolTimeView : MonoBehaviour
    {
        [SerializeField]
        private Text text;
        [SerializeField]
        private SkillCategory category;

        private Skill skill;

        void Start() {
            this.SetCategory(this.category);
            this.UpdateView().Forget();
        }

        private async UniTask UpdateView() {
            var token = this.GetCancellationTokenOnDestroy();
            while (true) {
                this.text.text = this.skill.CoolTime() ?? "00:00";
                await UniTask.Delay(TimeSpan.FromSeconds(1), cancellationToken: token);
            }
        }

        public void SetCategory(SkillCategory category) {
            this.category = category;
            this.skill = DIContainer.SkillRepository.GetSkill(this.category);
        }
    }
}
