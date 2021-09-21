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
            var now = DIContainer.TimeRepository.Now;
            var timeLeft = skill.TimeLeft(now);
            if (timeLeft > TimeSpan.Zero) {
                return timeLeft.ToString("mm\\:ss");
            }
            var coolTime = skill.CoolTime(now);
            if (coolTime > TimeSpan.Zero) {
                return coolTime.ToString("mm\\:ss");
            }
            return null;
        }

        public static float CoolTimeRate(this Skill skill) {
            var now = DIContainer.TimeRepository.Now;
            var timeLeft = skill.TimeLeft(now);
            if (timeLeft > TimeSpan.Zero) {
                return (float)timeLeft.Ticks / skill.MaxTimeLeft.Ticks;
            }
            var coolTime = skill.CoolTime(now);
            if (coolTime > TimeSpan.Zero) {
                return (float)coolTime.Ticks / skill.MaxCoolTime.Ticks;
            }
            return 0f;
        }
    }
}
