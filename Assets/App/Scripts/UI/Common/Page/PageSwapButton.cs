using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageSwapButton : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;

    public void OnClick() {
        PageRoot pageRoot = this.transform.root.GetComponentInChildren<PageRoot>();
        if (pageRoot == null) {
            return;
        }
        pageRoot.SwapChild(this.prefab);
    }
}
