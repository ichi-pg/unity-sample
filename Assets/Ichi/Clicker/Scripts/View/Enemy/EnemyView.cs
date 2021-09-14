using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

namespace Ichi.Clicker.View
{
    public class EnemyView : MonoBehaviour
    {
        [SerializeField]
        private Image image;
        [SerializeField]
        private Common.Gauge gauge;
        [SerializeField]
        private Sprite[] sprites;

        void Start() {
            DIContainer.EnemyRepository.AlterHandler += this.OnChange;
            DIContainer.EnemyRepository.Enemy.OnDamage.Subscribe(_ => this.OnAlter()).AddTo(this);
            this.OnChange();
        }

        void OnDestroy() {
            DIContainer.EnemyRepository.AlterHandler -= this.OnChange;
        }

        private void OnChange() {
            var enemy = DIContainer.EnemyRepository.Enemy;
            this.image.sprite = this.sprites[enemy.Rank - 1];
            this.OnAlter();
            //TODO 捕獲エフェクト
            //TODO SE
        }

        private void OnAlter() {
            var enemy = DIContainer.EnemyRepository.Enemy;
            this.gauge.Resize(Common.BigIntegerRate.Rate(enemy.Damage, enemy.HP));
        }
    }
}
