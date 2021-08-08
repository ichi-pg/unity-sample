using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void Change(GameObject prefab) {
        if (prefab == null) {
            return;
        }
        this.Clear();
        this.stack.Push(GameObject.Instantiate(prefab, this.transform));
    }

    public void Push(GameObject prefab) {
        if (prefab == null) {
            return;
        }
        if (this.stack.Count > 0) {
            this.stack.Peek().SetActive(false);
        }
        this.stack.Push(GameObject.Instantiate(prefab, this.transform));
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
