using System.Collections;
using System.Collections.Generic;
using System;
using UniRx;
using UnityEngine;

namespace Ichi.Clicker
{
    public class TimeProducer : MonoBehaviour
    {
        void Start() {
            Observable.Interval(TimeSpan.FromSeconds(1))
                .Subscribe(_ => this.TimeProduce())
                .AddTo(this);
        }

        private void TimeProduce() {
            var repository = Dependency.FactoryRepository;
            foreach (var factory in repository.AutoFactories) {
                if (!factory.IsLocked) {
                    repository.TimeProduce(factory);
                }
            }
            Ichi.Common.DataInjector.Modify();
        }
    }
}
