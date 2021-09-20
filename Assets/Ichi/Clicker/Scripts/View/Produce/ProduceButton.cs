using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System;
using UnityEngine;
using UniRx;

namespace Ichi.Clicker.View
{
    public class ProduceButton : MonoBehaviour
    {
        void Start() {
            if (DIContainer.EnemyRepository.Enemy == null) {
                DIContainer.EnemyRepository.Encount();
            }
            DIContainer.ClickerRepository.OnProduce.Subscribe(this.OnDamage).AddTo(this);
            DIContainer.FeverRepository.OnProduce.Subscribe(this.OnDamage).AddTo(this);
        }

        public void Produce() {
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
    }
}
