using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ichi.Clicker
{
    public class AutoProducer : MonoBehaviour
    {
        public const float FeverSeconds = 30.0f;
        public const float NormalInterval = 1.0f;
        public const float FeverInterval = 0.1f;
        private float interval = NormalInterval;

        IEnumerator Start() {
            var repository = Dependency.FactoryRepository;
            while (true) {
                foreach (var factory in repository.List()) {
                    if (!factory.IsLocked && factory.Category == (int)FactoryCategory.Auto) {
                        repository.Produce(factory);
                    }
                }
                Ichi.Common.DataInjector.Modify();
                yield return new WaitForSeconds(this.interval);
            }
        }

        IEnumerator Fever() {
            if (this.interval < NormalInterval) {
                yield break;
            }
            this.interval = FeverInterval;
            yield return new WaitForSeconds(FeverSeconds);
            this.interval = NormalInterval;
            //TODO 広告
            //TODO オート施設は放置時間増加
        }
    }
}
