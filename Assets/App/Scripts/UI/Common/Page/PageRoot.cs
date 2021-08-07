using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageRoot : MonoBehaviour
{
    void Start() {
        this.SwapChild("Title");
    }

    public void SwapChild(string prefabName) {
        foreach (Transform child in this.transform) {
            Destroy(child.gameObject);
        }
        GameObject prefab = Resources.Load("UI/Page/"+prefabName) as GameObject;
        Instantiate(prefab, this.transform);
    }
}
