using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ichi.Common.Extensions;

namespace Ichi.Common
{
    public class PageTransition : MonoBehaviour
    {
        [SerializeField]
        private GameObject page;

        public void Transition() {
            var canvas = this.GetComponentInParent<Canvas>().transform;
            canvas.DestroyChildren();
            Instantiate(this.page, canvas);
            //NOTE UI以外の画面遷移
            //NOTE 戻る
            //NOTE フッターなど重ねる系
            //NOTE フッターなどトグル表示
        }
    }
}
