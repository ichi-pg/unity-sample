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
            this.OnEncount(DIContainer.EnemyRepository.Enemy);
        }

        private void UpdateGauge(IEnemy enemy) {
            this.gauge.Resize(Common.Math.Divide(enemy.Damage, enemy.HP));
        }

        private void OnWin(IEnemy enemy) {
            //TODO 撃破エフェクト
            //TODO ハート貯まるエフェクト
            //TODO SE
        }

        private void OnEncount(IEnemy enemy) {
            if (enemy == null) {
                this.image.gameObject.SetActive(false);
                this.gauge.gameObject.SetActive(false);
                return;
            }
            this.image.gameObject.SetActive(true);
            this.gauge.gameObject.SetActive(true);
            this.image.sprite = this.sprites[enemy.Rank - 1];
            this.image.color = Color.white;
            this.UpdateGauge(enemy);
            //TODO 名前描画（諸説）
            //TODO レベル描画
            //TODO 希少性描画
            //TODO エフェクト
            //TODO 希少性エフェクト
            //TODO SE
        }

        private void OnDamage(BigInteger damage) {
            this.UpdateGauge(DIContainer.EnemyRepository.Enemy);
            //TODO ダメージ満タン再起動で進行不可能になる
            //TODO キャラもアニメしないと物足りない。表情も変えたい。欲を言えばLive2D。
        }
    }
}
