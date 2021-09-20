using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx.Toolkit;

namespace Ichi.Common
{
    public class PointGenerator : MonoBehaviour
    {
        [SerializeField]
        private GameObject prefab;
        [SerializeField]
        private Transform target;

        private PoolablePool pool;

        void Start() {
            this.pool = new PoolablePool(this.prefab, this.target);
        }

        public T Generate<T>() where T : Component {
            var res = this.pool.Rent();
            res.transform.localPosition = Vector3.zero;
            return res.GetComponent<T>();
        }
    }
}
