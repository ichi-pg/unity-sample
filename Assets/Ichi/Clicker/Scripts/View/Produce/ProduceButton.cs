using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

namespace Ichi.Clicker.View
{
    public class ProduceButton : MonoBehaviour
    {
        [SerializeField]
        private Button button;
        [SerializeField]
        private CanvasGroup tap;
        [SerializeField]
        private Common.DelayCanceler delayCanceler;

        void Start() {
            if (DIContainer.EnemyRepository.Enemy == null) {
                DIContainer.EnemyRepository.Encount();
            }
            DIContainer.EnemyRepository.OnEncount.Subscribe(this.OnEncount).AddTo(this);
            DIContainer.EnemyRepository.OnWin.Subscribe(this.OnWin).AddTo(this);
            DIContainer.ClickerRepository.OnProduce.Subscribe(this.OnDamage).AddTo(this);
            DIContainer.FeverRepository.OnProduce.Subscribe(this.OnFeverDamage).AddTo(this);
            this.button.OnClickAsObservable().Subscribe(_ => this.Produce()).AddTo(this);
            this.tap.gameObject.SetActive(false);
        }

        private void Produce() {
            if (DIContainer.EnemyRepository.Enemy == null) {
                DIContainer.EnemyRepository.Encount();
                return;
            }
            if (DIContainer.EnemyRepository.Enemy.IsAlive) {
                DIContainer.ClickerRepository.Produce();
                return;
            }
            DIContainer.EnemyRepository.Win();
        }

        private void OnDamage(BigInteger damage) {
            if (DIContainer.EnemyRepository.Enemy.IsAlive) {
                return;
            }
            DIContainer.EnemyRepository.Win();
        }

        private void OnFeverDamage(BigInteger damage) {
            if (DIContainer.EnemyRepository.Enemy.IsAlive) {
                return;
            }
            DIContainer.EnemyRepository.Win();
            DIContainer.EnemyRepository.Encount();
        }

        private void OnWin(IEnemy enemy) {
            this.delayCanceler.Execute(
                () => this.tap.gameObject.SetActive(true),
                TimeSpan.FromSeconds(1)
            );
        }

        private void OnEncount(IEnemy enemy) {
            this.delayCanceler.Execute(
                () => this.tap.gameObject.SetActive(false),
                TimeSpan.Zero
            );
        }
    }
}
