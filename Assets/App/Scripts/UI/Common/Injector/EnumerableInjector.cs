using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumerableInjector : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;

    public void Inject(IEnumerable enumerable) {
        foreach (Transform child in this.transform) {
            Destroy(child.gameObject);
        }
        foreach (object obj in enumerable) {
            GameObject gameObj = Instantiate(this.prefab, this.transform);
            PropertyInjector injector = gameObj.GetComponent<PropertyInjector>();
            if (injector == null) {
                continue;
            }
            injector.Inject(obj);
        }
    }
}
