using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx.Toolkit;

namespace Ichi.Common
{
    public class Poolable : MonoBehaviour
    {
        private ObjectPool<Poolable> pool;

        public void SetPool(ObjectPool<Poolable> pool) {
            this.pool = pool;
        }

        public void Return() {
            this.pool.Return(this);
        }
    }
}
