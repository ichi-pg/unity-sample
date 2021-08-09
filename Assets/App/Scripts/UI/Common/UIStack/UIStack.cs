using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class UIStack : MonoBehaviour
{
    public enum Layer
    {
        Page,
        Modal,
    }

    public static UIStack Instance { get; private set; }
    private Dictionary<Layer, UIStackLayer> layers = new Dictionary<Layer, UIStackLayer>();

    void Start() {
        foreach (Layer layer in Enum.GetValues(typeof(Layer))) {
            this.layers.Add(layer, new UIStackLayer(this.transform));
        }
        this.layers[Layer.Page].PushChildren();
        Instance = this;
    }

    public void Clear(Layer layer) {
        this.layers[layer].Clear();
    }

    public void Push(Layer layer, string prefabName, object data) {
        this.layers[layer].Push(prefabName, data);
    }

    public void Pop(Layer layer) {
        this.layers[layer].Pop();
    }
}
