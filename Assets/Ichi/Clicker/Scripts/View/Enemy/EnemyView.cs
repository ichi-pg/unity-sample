using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using DG.Tweening;

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
            DIContainer.ClickerRepository.OnProduce.Subscribe(_ => this.OnDamage()).AddTo(this);
            this.UpdateEnemy();
        }

        private void UpdateEnemy() {
            var enemy = DIContainer.EnemyRepository.Enemy;
            this.image.sprite = this.sprites[enemy.Rank - 1];
            this.UpdateGauge();
        }

        private void UpdateGauge() {
            var enemy = DIContainer.EnemyRepository.Enemy;
            this.gauge.Resize(Common.BigIntegerRate.Rate(enemy.Damage, enemy.HP));
        }

        private void OnEncount() {
            this.UpdateEnemy();
            //TODO 捕獲エフェクト
            //TODO SE
        }

        private void OnDamage() {
            this.UpdateGauge();
            //TODO キャラもアニメしないと物足りない。表情も変えたい。欲を言えばLive2D。
        }
    }
}
