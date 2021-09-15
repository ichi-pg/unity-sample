using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System;
using UnityEngine;
using UniRx;
using Zenject;

namespace Ichi.Clicker.View
{
    public class DamageGenerator : MonoBehaviour
    {
        [Inject]
        private IClickerRepository clickerRepository;
        [SerializeField]
        private Common.RandomGenerator generater;

        void Start() {
            this.clickerRepository.OnProduce.Subscribe(this.OnDamage).AddTo(this);
        }

        private void OnDamage(BigInteger damage) {
            this.generater.Generate().GetComponent<DamageAnimation>().SetDamage(damage);
        }
    }
}
