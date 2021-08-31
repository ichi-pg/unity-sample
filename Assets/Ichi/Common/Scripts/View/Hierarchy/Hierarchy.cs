using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ichi.Common
{
    public static class Hierarchy
    {
        public static void InstantiateChildren<T, U>(Transform transform, GameObject prefab, IEnumerable<U> children) where T : IChildView<U> {
            foreach(var child in children){
                GameObject.Instantiate(prefab, transform).GetComponent<T>()?.Initialize(child);
            }
        }

        public static void DestroyChildren(Transform transform) {
            foreach(Transform child in transform){
                Object.Destroy(child.gameObject);
            }
        }

        public static void SetActiveChildren(Transform parent, bool active) {
            foreach (Transform child in parent) {
                child.gameObject.SetActive(active);
            }
        }

        public static Transform FindParentIn<T>(Transform transform) where T : Object {
            while (transform.parent.GetComponent<T>() == null) {
                transform = transform.parent;
            }
            return transform;
        }

        //NOTE LINQ to GameObject
    }
}
