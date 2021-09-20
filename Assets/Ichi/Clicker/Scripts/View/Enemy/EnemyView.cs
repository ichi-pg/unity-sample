using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using DG.Tweening;
using Vector3 = UnityEngine.Vector3;

namespace Ichi.Clicker.View
{
    public class EnemyView : MonoBehaviour
    {
        [SerializeField]
        private Image image;
        [SerializeField]
        private Common.Gauge gauge;
        [SerializeField]
        private CanvasGroup lifeBar;
        [SerializeField]
        private Sprite[] sprites;

        void Start() {
            DIContainer.EnemyRepository.OnWin.Subscribe(this.OnWin).AddTo(this);
            DIContainer.EnemyRepository.OnEncount.Subscribe(this.OnEncount).AddTo(this);
            DIContainer.ClickerRepository.OnProduce.Subscribe(this.OnDamage).AddTo(this);
            DIContainer.FeverRepository.OnProduce.Subscribe(this.OnDamage).AddTo(this);
            this.OnEncount(DIContainer.EnemyRepository.Enemy);
            this.image.transform.DOScale(0.99f, 3f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
        }

        private void UpdateGauge(IEnemy enemy) {
            this.gauge.Resize(Common.Math.Divide(enemy.Damage, enemy.HP));
        }

        private void OnWin(IEnemy enemy) {
            this.image.DOFade(0f, 0.5f);
            this.lifeBar.DOFade(0f, 0.5f);
            //TODO 懐いた感じのエフェクト
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
            this.image.color = new Color(1f, 1f, 1f, 0f);
            this.lifeBar.alpha = 0f;
            this.image.DOFade(1f, 0.5f);
            this.lifeBar.DOFade(1f, 0.5f);
            this.UpdateGauge(enemy);
            //TODO 名前、レベル描画
            //TODO 希少性表現
            //TODO SE
        }

        private void OnDamage(BigInteger damage) {
            this.UpdateGauge(DIContainer.EnemyRepository.Enemy);
            //TODO キャラもアニメしないと物足りない。表情も変えたい。欲を言えばLive2D。
        }
    }
}
