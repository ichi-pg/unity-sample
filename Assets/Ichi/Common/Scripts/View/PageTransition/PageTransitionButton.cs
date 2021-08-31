using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ichi.Common
{
    public class PageTransitionButton : MonoBehaviour
    {
        [SerializeField]
        private GameObject page;

        public void Transition() {
            var canvas = this.GetComponentInParent<Canvas>();
            Hierarchy.DestroyChildren(canvas.transform);
            Instantiate(this.page, canvas.transform);
            //TODO UI以外の画面遷移
            //TODO 戻る
            //TODO フッターなど重ねる系
            //TODO フッターなどトグル表示
        }
    }
}
