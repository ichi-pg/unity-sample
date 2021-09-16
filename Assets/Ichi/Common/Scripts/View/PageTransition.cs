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
            //TODO UI以外の画面遷移
            //TODO 戻る
            //TODO フッターなど重ねる系
            //TODO フッターなどトグル表示
        }
    }
}
