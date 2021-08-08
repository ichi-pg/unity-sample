using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStackButton : MonoBehaviour
{
    [SerializeField]
    private UIStack.Layer layer;
    [SerializeField]
    private GameObject prefab;

    public void Clear() {
        UIStack.Instance.Clear(this.layer);
    }

    public void Change() {
        UIStack.Instance.Change(this.layer, this.prefab);
    }

    public void Push() {
        UIStack.Instance.Push(this.layer, this.prefab);
    }

    public void Pop() {
        UIStack.Instance.Pop(this.layer);
    }
}
