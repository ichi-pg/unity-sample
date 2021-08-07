using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageSwapButton : MonoBehaviour
{
    [SerializeField]
    private string prefabName;

    public void OnClick() {
        PageRoot.Instance.SwapChild(this.prefabName);
    }
}
