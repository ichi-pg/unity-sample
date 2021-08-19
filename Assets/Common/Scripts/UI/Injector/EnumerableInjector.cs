using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common
{
    public class EnumerableInjector : MonoBehaviour
    {
        public void Clear() {
            foreach (Transform child in this.transform) {
                Destroy(child.gameObject);
            }
        }

        public void InjectList(IEnumerable enumerable, GameObject prefab) {
            foreach (object data in enumerable) {
                this.Inject(data, prefab);
            }
        }

        public void Inject(object data, GameObject prefab) {
            var obj = Instantiate(prefab, this.transform);
            var injector = obj.GetComponent<PropertyInjector>();
            if (injector != null) {
                injector.Inject(data);
            }
        }
    }
}
