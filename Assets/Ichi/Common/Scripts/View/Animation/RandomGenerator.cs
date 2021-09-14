using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ichi.Common
{
    public class RandomGenerator : MonoBehaviour
    {
        [SerializeField]
        private GameObject prefab;
        [SerializeField]
        private RectTransform target;

        public GameObject Generate() {
            var obj = GameObject.Instantiate(this.prefab, this.target);
            var rect = this.target.rect;
            var x = Random.Range(0, rect.width) - rect.width / 2;
            var y = Random.Range(0, rect.height) - rect.height / 2;
            obj.transform.localPosition = new Vector3(x, y , 0);
            return obj;
        }

        //TODO オブジェクトプール
    }
}
