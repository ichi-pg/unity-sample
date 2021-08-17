using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Clicker
{
    public class AutoProducer : MonoBehaviour
    {
        private float feverRate = 1.0f;

        IEnumerator Start() {
            var injector = this.GetComponent<Common.PropertyInjector>();
            while (injector.Data == null) {
                yield return null;
            }
            var adapter = injector.Data as FactoryAdapter;
            while (true) {
                yield return new WaitForSeconds(adapter.Factory.Interval*this.feverRate);
                adapter.Produce();
            }
        }

        public IEnumerator Fever() {
            if (this.feverRate < 1.0f) {
                yield break;
            }
            this.feverRate = 0.1f;
            yield return new WaitForSeconds(30.0f);
            this.feverRate = 1.0f;
            //TODO ドメイン？
            //TODO 広告
        }
    }
}
