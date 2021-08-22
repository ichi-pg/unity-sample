using System.Collections;
using System.Collections.Generic;
using System;
using UniRx;
using UnityEngine;

namespace Ichi.Clicker
{
    public class AutoCollector : MonoBehaviour
    {
        void Start() {
            Observable.Interval(TimeSpan.FromSeconds(1))
                .Subscribe(_ => this.Collect())
                .AddTo(this);
        }

        private void Collect() {
            var repository = Dependency.FactoryRepository;
            foreach (var factory in repository.AutoFactories) {
                repository.Collect(factory);
            }
            Ichi.Common.DataInjector.Modify();
        }
    }
}
