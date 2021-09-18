using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ichi.Clicker.View
{
    public class ProduceButton : MonoBehaviour
    {
        public void Produce() {
            if (DIContainer.EnemyRepository.Enemy.IsAlive) {
                DIContainer.ClickerRepository.Produce();
            } else {
                DIContainer.EnemyRepository.Encount();
                //TODO 演出してスムーズに移動
            }
        }
    }
}
