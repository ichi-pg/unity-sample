using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System;
using UnityEngine;
using UniRx;

namespace Ichi.Clicker.View
{
    public class DamageGenerator : MonoBehaviour
    {
        [SerializeField]
        private Common.RandomGenerator generater;

        void Start() {
            DIContainer.ClickerRepository.OnProduce.Subscribe(this.OnDamage).AddTo(this);
        }

        private void OnDamage(BigInteger damage) {
            this.generater.Generate().GetComponent<DamageAnimation>().SetDamage(damage);
        }
    }
}
