using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumerableInjector : MonoBehaviour
{
    [SerializeField]
    private string prefabName;

    public void Inject(IEnumerable enumerable) {
        if (enumerable == null) {
            return;
        }
        foreach (Transform child in this.transform) {
            Destroy(child.gameObject);
        }
        foreach (object data in enumerable) {
            GameObject prefab = Resources.Load<GameObject>("UI/Item/"+this.prefabName);
            GameObject obj = Instantiate(prefab, this.transform);
            PropertyInjector injector = obj.GetComponent<PropertyInjector>();
            if (injector != null) {
                injector.Inject(data);
            }
        }
    }
}
