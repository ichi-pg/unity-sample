using System.Collections;
using System.Collections.Generic;
using System.Numerics;
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
            DIContainer.EnemyRepository.OnWin.Subscribe(this.OnWin).AddTo(this);
            DIContainer.EnemyRepository.OnEncount.Subscribe(this.OnEncount).AddTo(this);
            DIContainer.ClickerRepository.OnProduce.Subscribe(this.OnDamage).AddTo(this);
            DIContainer.FeverRepository.OnProduce.Subscribe(this.OnDamage).AddTo(this);
            this.UpdateEnemy();
        }

        private void UpdateEnemy() {
            var enemy = DIContainer.EnemyRepository.Enemy;
            this.image.sprite = this.sprites[enemy.Rank - 1];
            this.UpdateGauge();
            //TODO 名前描画（諸説）
            //TODO レベル描画
            //TODO 希少性描画
        }

        private void UpdateGauge() {
            var enemy = DIContainer.EnemyRepository.Enemy;
            this.gauge.Resize(Common.Math.Divide(enemy.Damage, enemy.HP));
        }

        private void OnWin(IEnemy enemy) {
            //TODO 撃破エフェクト
            //TODO ハート貯まるエフェクト
            //TODO SE
        }

        private void OnEncount(IEnemy enemy) {
            this.UpdateEnemy();
            //TODO エフェクト
            //TODO 希少性エフェクト
            //TODO SE
        }

        private void OnDamage(BigInteger damage) {
            this.UpdateGauge();
            if (!DIContainer.EnemyRepository.Enemy.IsAlive) {
                DIContainer.EnemyRepository.Win();
            }
            //TODO キャラもアニメしないと物足りない。表情も変えたい。欲を言えばLive2D。
        }
    }
}
