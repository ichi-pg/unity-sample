using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ichi.Common
{
    public class AnimationCreater : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] animations;
        [SerializeField]
        private RectTransform region;

        public void Create(int index = 0) {
            var obj = Instantiate(this.animations[index], this.region);
            var x = Random.Range(0, this.region.rect.width) - this.region.rect.width / 2;
            var y = Random.Range(0, this.region.rect.height) - this.region.rect.height / 2;
            obj.transform.localPosition = new Vector3(x, y , 0);
        }
    }
}
