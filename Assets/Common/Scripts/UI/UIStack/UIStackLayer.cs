using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common
{
    public class UIStackLayer
    {
        private Transform transform;
        private Stack<GameObject> stack = new Stack<GameObject>();

        public UIStackLayer(Transform transform) {
            this.transform = transform;
        }

        public void PushChildren() {
            foreach (Transform child in this.transform) {
                this.stack.Push(child.gameObject);
            }
        }

        public void Clear() {
            foreach (Transform child in this.transform) {
                GameObject.Destroy(child.gameObject);
            }
            this.stack.Clear();
        }

        public void Push(string prefabName, object data) {
            GameObject prefab = Resources.Load<GameObject>(prefabName);
            if (prefab == null) {
                return;
            }
            if (this.stack.Count > 0) {
                this.stack.Peek().SetActive(false);
            }
            GameObject obj = GameObject.Instantiate(prefab, this.transform);
            if (data != null) {
                PropertyInjector injector = obj.GetComponent<PropertyInjector>();
                if (injector != null) {
                    injector.Inject(data);
                }
            }
            this.stack.Push(obj);
        }

        public void Pop() {
            if (this.stack.Count > 0) {
                GameObject.Destroy(this.stack.Pop());
            }
            if (this.stack.Count > 0) {
                this.stack.Peek().SetActive(true);
            }
        }
    }
}
