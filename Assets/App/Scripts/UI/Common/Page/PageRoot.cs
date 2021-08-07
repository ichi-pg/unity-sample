using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageRoot : MonoBehaviour
{
    public void SwapChild(string prefabName) {
        this.SwapChild(Resources.Load(prefabName) as GameObject);
    }

    public void SwapChild(GameObject prefab) {
        if (prefab == null) {
            return;
        }
        foreach (Transform child in this.transform) {
            Destroy(child.gameObject);
        }
        Instantiate(prefab, this.transform);
    }
}
