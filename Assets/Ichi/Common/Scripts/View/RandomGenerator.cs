using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx.Toolkit;

namespace Ichi.Common
{
    public class RandomGenerator : MonoBehaviour
    {
        [SerializeField]
        private GameObject prefab;
        [SerializeField]
        private RectTransform target;

        private PoolablePool pool;

        void Start() {
            this.pool = new PoolablePool(this.prefab, this.target);
        }

        public T Generate<T>() where T : Component {
            var rect = this.target.rect;
            var x = Random.Range(0, rect.width) - rect.width / 2;
            var y = Random.Range(0, rect.height) - rect.height / 2;
            var res = this.pool.Rent();
            res.transform.localPosition = new Vector3(x, y , 0);
            return res.GetComponent<T>();
        }
    }
}
