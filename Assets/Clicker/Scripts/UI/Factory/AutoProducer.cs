using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Clicker
{
    public class AutoProducer : MonoBehaviour
    {
        void Start() {
            this.StartCoroutine("Execute");
        }

        private IEnumerator Execute() {
            var injector = this.GetComponent<Common.PropertyInjector>();
            while (injector.Data == null) {
                yield return null;
            }
            var adapter = injector.Data as FactoryAdapter;
            while (true) {
                yield return new WaitForSeconds(adapter.Factory.AutoProduceInterval);
                if (adapter.LevelUpActive) {
                    adapter.Produce();
                }
            }
        }

        //TODO オートモードとタップモードの切り替え（楽 or 効率）
    }
}
