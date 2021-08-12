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

        public void Inject(IEnumerable enumerable, string prefabName) {
            if (enumerable == null) {
                return;
            }
            GameObject prefab = Resources.Load<GameObject>(prefabName);
            if (prefab == null) {
                return;
            }
            foreach (object data in enumerable) {
                GameObject obj = Instantiate(prefab, this.transform);
                PropertyInjector injector = obj.GetComponent<PropertyInjector>();
                if (injector != null) {
                    injector.Inject(data);
                }
            }
        }
    }
}
