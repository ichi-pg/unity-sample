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

        public void InjectList(IEnumerable enumerable, GameObject prefab, IResourceLoader loader) {
            foreach (object data in enumerable) {
                this.Inject(data, prefab, loader);
            }
        }

        public void Inject(object data, GameObject prefab, IResourceLoader loader) {
            var obj = Instantiate(prefab, this.transform);
            var injector = obj.GetComponent<PropertyInjector>();
            if (injector != null) {
                injector.Inject(data, loader);
            }
        }
    }
}
