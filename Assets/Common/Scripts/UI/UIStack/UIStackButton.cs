using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common
{
    public class UIStackButton : MonoBehaviour
    {
        [SerializeField]
        private UIStack.Layer layer;
        [SerializeField]
        private GameObject prefab;
        [SerializeField]
        private PropertyInjector injector;

        public void Clear() {
            UIStack.Instance.Clear(this.layer);
        }

        public void Change() {
            UIStack.Instance.Clear(this.layer);
            this.Push();
        }

        public void Push() {
            //TODO ローダーの注入方法
            UIStack.Instance.Push(this.layer, this.prefab, this.injector?.Data, new ResourceLoader());
        }

        public void Pop() {
            UIStack.Instance.Pop(this.layer);
        }
    }
}
