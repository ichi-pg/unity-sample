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
            DIContainer.EnemyRepository.AlterHandler += this.OnChange;
            DIContainer.EnemyRepository.Enemy.AlterHandler += this.OnAlter;
            this.OnChange();
        }

        void OnDestroy() {
            DIContainer.EnemyRepository.AlterHandler -= this.OnChange;
            DIContainer.EnemyRepository.Enemy.AlterHandler -= this.OnAlter;
        }

        private void OnChange() {
            var enemy = DIContainer.EnemyRepository.Enemy;
            this.image.sprite = this.sprites[enemy.Rank - 1];
            //TODO 捕獲エフェクト
            //TODO SE
        }

        private void OnAlter() {
            //TODO ダメージエフェクト
            //TODO SE
        }
    }
}
