using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Ichi.Clicker.View
{
    public static class SkillExtensions
    {
        public static string CoolTime(this Skill skill) {
            var timeLeft = skill.TimeLeft(DIContainer.TimeRepository.Now);
            var coolTime = skill.CoolTime(DIContainer.TimeRepository.Now);
            if (timeLeft > TimeSpan.Zero) {
                return timeLeft.ToString("mm\\:ss");
            }
            if (coolTime > TimeSpan.Zero) {
                return coolTime.ToString("mm\\:ss");
            }
            return null;
        }
    }
}
