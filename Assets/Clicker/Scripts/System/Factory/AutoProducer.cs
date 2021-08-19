using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Clicker
{
    public class AutoProducer : MonoBehaviour
    {
        private float interval = 1.0f;

        IEnumerator Start() {
            var repository = Repositories.Instance.FactoryRepository;
            while (true) {
                foreach (var factory in repository.List()) {
                    repository.Produce(factory);
                }
                Common.PropertyInjector.Modify();
                yield return new WaitForSeconds(this.interval);
            }
        }

        public IEnumerator Fever() {
            if (this.interval < 1.0f) {
                yield break;
            }
            this.interval = 0.1f;
            yield return new WaitForSeconds(30.0f);
            this.interval = 1.0f;
            //TODO ドメイン？
            //TODO 広告
        }
    }
}
