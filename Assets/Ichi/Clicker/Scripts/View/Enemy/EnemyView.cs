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
            DIContainer.EnemyRepository.OnEncount.Subscribe(_ => this.OnEncount()).AddTo(this);
            DIContainer.EnemyRepository.Enemy.OnDamage.Subscribe(_ => this.OnDamage()).AddTo(this);
            this.OnEncount();
        }

        private void OnEncount() {
            var enemy = DIContainer.EnemyRepository.Enemy;
            this.image.sprite = this.sprites[enemy.Rank - 1];
            this.OnDamage();
            //TODO 捕獲エフェクト
            //TODO SE
        }

        private void OnDamage() {
            var enemy = DIContainer.EnemyRepository.Enemy;
            this.gauge.Resize(Common.BigIntegerRate.Rate(enemy.Damage, enemy.HP));
        }
    }
}
