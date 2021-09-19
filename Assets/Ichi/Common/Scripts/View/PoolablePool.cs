using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx.Toolkit;

namespace Ichi.Common
{
    public class PoolablePool : ObjectPool<Poolable> {

        private Transform parent;
        private GameObject prefab;

        public PoolablePool(GameObject prefab, Transform parent) {
            this.prefab = prefab;
            this.parent = parent;
        }

        protected override Poolable CreateInstance() {
            var obj = GameObject.Instantiate(this.prefab, this.parent);
            var comp = obj.GetComponent<Poolable>();
            comp.SetPool(this);
            return comp;
        }
    }
}
