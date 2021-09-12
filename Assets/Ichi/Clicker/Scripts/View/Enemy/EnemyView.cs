using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Ichi.Clicker.View
{
    public class EnemyView : MonoBehaviour
    {
        [SerializeField]
        private Image image;
        [SerializeField]
        private Sprite[] sprites;

        void Start() {
            DIContainer.EnemyRepository.Enemy.AlterHandler += this.OnAlter;
            this.OnAlter();
        }

        void OnDestroy() {
            DIContainer.EnemyRepository.Enemy.AlterHandler -= this.OnAlter;
        }

        private void OnAlter() {
            //TODO
            var enemy = DIContainer.EnemyRepository.Enemy;
            this.image.sprite = this.sprites[enemy.Rank - 1];
        }
    }
}
