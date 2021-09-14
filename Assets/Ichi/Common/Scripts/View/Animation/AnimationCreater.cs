using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ichi.Common
{
    public static class AnimationCreater
    {
        public static GameObject Create(GameObject prefab, RectTransform target) {
            var obj = GameObject.Instantiate(prefab, target);
            var x = Random.Range(0, target.rect.width) - target.rect.width / 2;
            var y = Random.Range(0, target.rect.height) - target.rect.height / 2;
            obj.transform.localPosition = new Vector3(x, y , 0);
            return obj;
        }

        //TODO アニメじゃなくて単にランダム生成クラスやね
    }
}
