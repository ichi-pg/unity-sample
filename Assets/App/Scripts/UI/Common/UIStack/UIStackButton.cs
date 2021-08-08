using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStackButton : MonoBehaviour
{
    [SerializeField]
    private UIStack.Layer layer;
    [SerializeField]
    private string prefabName;

    public void Clear() {
        UIStack.Instance.Clear(this.layer);
    }

    public void Change() {
        UIStack.Instance.Change(this.layer, this.prefabName);
    }

    public void Push() {
        UIStack.Instance.Push(this.layer, this.prefabName);
    }

    public void Pop() {
        UIStack.Instance.Pop(this.layer);
    }
}
