using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common
{
    public class PageTransitionButton : MonoBehaviour
    {
        [SerializeField]
        private GameObject page;

        public void Transition() {
            var canvas = this.GetComponentInParent<Canvas>();
            HierarchyDestroy.DestroyChildren(canvas.transform);
            Instantiate(this.page, canvas.transform);
            //TODO UI以外の画面遷移
            //TODO 戻る
            //TODO フッターなど重ねる系
            //TODO フッターなどトグル表示
        }
    }
}
