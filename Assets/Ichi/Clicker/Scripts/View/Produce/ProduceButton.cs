using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ichi.Clicker.View
{
    public class ProduceButton : MonoBehaviour
    {
        void Start() {
            if (DIContainer.EnemyRepository.Enemy == null) {
                DIContainer.EnemyRepository.Encount();
            }
        }

        public void Produce() {
            //TODO 演出してスムーズに移動
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
    }
}
