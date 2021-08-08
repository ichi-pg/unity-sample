using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class UIStack : MonoBehaviour
{
    public enum Layer
    {
        Page,
        Modal
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

    public void Change(Layer layer, string prefabName) {
        this.layers[layer].Change(this.GetPrefab(layer, prefabName));
    }

    public void Push(Layer layer, string prefabName) {
        this.layers[layer].Push(this.GetPrefab(layer, prefabName));
    }

    public void Pop(Layer layer) {
        this.layers[layer].Pop();
    }

    private GameObject GetPrefab(Layer layer, string prefabName) {
        return Resources.Load<GameObject>("UI/"+Enum.GetName(typeof(Layer), layer)+"/"+prefabName);
    }
}
