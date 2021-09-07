using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ichi.Common
{
    public class AnimationCreater : MonoBehaviour
    {
        [SerializeField]
        private GameObject animation;
        [SerializeField]
        private RectTransform region;

        public void Create() {
            var obj = Instantiate(animation, this.region);
            var x = Random.Range(0, region.rect.width) - region.rect.width / 2;
            var y = Random.Range(0, region.rect.height) - region.rect.height / 2;
            obj.transform.localPosition = new Vector3(x, y , 0);
        }
    }
}
