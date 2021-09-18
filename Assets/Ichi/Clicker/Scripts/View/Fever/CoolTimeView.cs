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

        void Start() {
            this.UpdateView().Forget();
        }

        private async UniTask UpdateView() {
            var token = this.GetCancellationTokenOnDestroy();
            var skill = DIContainer.SkillRepository.GetSkill(this.category);
            while (true) {
                this.text.text = skill.CoolTime() ?? "00:00";
                await UniTask.Delay(TimeSpan.FromSeconds(1), cancellationToken: token);
            }
        }
    }
}
