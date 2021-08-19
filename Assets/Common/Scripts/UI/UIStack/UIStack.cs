using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common
{
    public class UIStack : MonoBehaviour
    {
        //TODO レイヤー削除
        public enum Layer
        {
            Page,
            Modal,
        }

        public static UIStack Instance { get; private set; }
        private Dictionary<Layer, UIStackLayer> layers = new Dictionary<Layer, UIStackLayer>();

        void Start() {
            foreach (Layer layer in System.Enum.GetValues(typeof(Layer))) {
                this.layers.Add(layer, new UIStackLayer(this.transform));
            }
            this.layers[Layer.Page].PushChildren();
            Instance = this;
        }

        public void Clear(Layer layer) {
            this.layers[layer].Clear();
        }

        public void Push(Layer layer, GameObject prefab, object data, IResourceLoader loader) {
            this.layers[layer].Push(prefab, data, loader);
        }

        public void Pop(Layer layer) {
            this.layers[layer].Pop();
        }
    }
}
