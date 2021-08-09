using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStackButton : MonoBehaviour
{
    [SerializeField]
    private UIStack.Layer layer;
    [SerializeField]
    private string prefabName;
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
        UIStack.Instance.Push(this.layer, this.prefabName, this.injector?.Data);
    }

    public void Pop() {
        UIStack.Instance.Pop(this.layer);
    }
}
