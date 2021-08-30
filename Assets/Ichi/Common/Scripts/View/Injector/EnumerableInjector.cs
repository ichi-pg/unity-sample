using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ichi.Common
{
    public class EnumerableInjector : MonoBehaviour
    {
        public void Clear() {
            HierarchyDestroy.DestroyChildren(this.transform);
        }

        public void InjectList(IEnumerable enumerable, GameObject prefab, IResourceLoader loader) {
            foreach (object data in enumerable) {
                this.Inject(data, prefab, loader);
            }
        }

        public void Inject(object data, GameObject prefab, IResourceLoader loader) {
            var obj = Instantiate(prefab, this.transform);
            var injector = obj.GetComponent<DataInjector>();
            if (injector != null) {
                injector.Inject(data, loader);
            }
        }
    }
}
