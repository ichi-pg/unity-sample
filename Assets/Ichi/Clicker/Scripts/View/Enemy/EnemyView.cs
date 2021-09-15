using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using DG.Tweening;
using Zenject;

namespace Ichi.Clicker.View
{
    public class EnemyView : MonoBehaviour
    {
        [Inject]
        private IEnemyRepository enemyRepository;
        [Inject]
        private IClickerRepository clickerRepository;
        [SerializeField]
        private Image image;
        [SerializeField]
        private Common.Gauge gauge;
        [SerializeField]
        private Sprite[] sprites;

        void Start() {
            this.enemyRepository.OnEncount.Subscribe(this.OnEncount).AddTo(this);
            this.clickerRepository.OnProduce.Subscribe(this.OnDamage).AddTo(this);
            this.UpdateEnemy();
        }

        private void UpdateEnemy() {
            var enemy = this.enemyRepository.Enemy;
            this.image.sprite = this.sprites[enemy.Rank - 1];
            this.UpdateGauge();
        }

        private void UpdateGauge() {
            var enemy = this.enemyRepository.Enemy;
            this.gauge.Resize(Common.BigIntegerRate.Rate(enemy.Damage, enemy.HP));
        }

        private void OnEncount(IEnemy enemy) {
            this.UpdateEnemy();
            //NOTE エフェクト
            //NOTE SE
        }

        private void OnDamage(BigInteger damage) {
            this.UpdateGauge();
            //TODO キャラもアニメしないと物足りない。表情も変えたい。欲を言えばLive2D。
        }
    }
}
