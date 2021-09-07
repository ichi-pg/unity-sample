using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ichi.Common
{
    public static class AnimationCreater
    {
        public static GameObject Create(GameObject prefab, RectTransform region) {
            var obj = GameObject.Instantiate(prefab, region);
            var x = Random.Range(0, region.rect.width) - region.rect.width / 2;
            var y = Random.Range(0, region.rect.height) - region.rect.height / 2;
            obj.transform.localPosition = new Vector3(x, y , 0);
            return obj;
        }
    }
}
