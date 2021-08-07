using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageSwapButton : MonoBehaviour
{
    [SerializeField]
    private string prefabName;

    public void OnClick() {
        PageRoot pageRoot = this.transform.root.GetComponent<PageRoot>();
        if (pageRoot == null) {
            return;
        }
        pageRoot.SwapChild(this.prefabName);
    }
}
