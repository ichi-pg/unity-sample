using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System;
using UnityEngine;
using UniRx;

namespace Ichi.Clicker.View
{
    public class DamageCreater : MonoBehaviour
    {
        [SerializeField]
        private GameObject prefab;
        [SerializeField]
        private RectTransform target;

        void Start() {
            DIContainer.EnemyRepository.Enemy.OnDamage.Subscribe(this.OnDamage).AddTo(this);
        }

        private void OnDamage(BigInteger damage) {
            var obj = Common.AnimationCreater.Create(this.prefab, this.target);
            obj.GetComponent<DamageAnimation>().SetDamage(damage);
        }
    }
}
