using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Clicker
{
    public class AutoProducer : MonoBehaviour
    {
        public const float FeverSeconds = 30.0f;
        public const float NormalInterval = 1.0f;
        public const float FeverInterval = 0.1f;
        private float interval = NormalInterval;

        IEnumerator Start() {
            var repository = Repositories.Instance.FactoryRepository;
            while (true) {
                foreach (var factory in repository.List()) {
                    if (!factory.IsLocked) {
                        repository.Produce(factory);
                    }
                }
                Common.PropertyInjector.Modify();
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
            //TODO ドメイン？
            //TODO 広告
        }
    }
}
