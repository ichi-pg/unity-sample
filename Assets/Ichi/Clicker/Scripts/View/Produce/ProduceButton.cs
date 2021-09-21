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

        void Start() {
            if (DIContainer.EnemyRepository.Enemy == null) {
                DIContainer.EnemyRepository.Encount();
            }
            DIContainer.ClickerRepository.OnProduce.Subscribe(this.OnDamage).AddTo(this);
            DIContainer.FeverRepository.OnProduce.Subscribe(this.OnFeverDamage).AddTo(this);
            this.button.OnClickAsObservable().Subscribe(_ => this.Produce()).AddTo(this);
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
            //TODO 撃破中の空白にタップ誘導
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
    }
}
