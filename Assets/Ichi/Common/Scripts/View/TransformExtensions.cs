using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ichi.Common.Extensions
{
    public static class TransformExtensions
    {
        public static void InstantiateChildren<T, U>(this Transform transform, GameObject prefab, IEnumerable<U> children) where T : IChildView<U> {
            foreach (var child in children) {
                GameObject.Instantiate(prefab, transform).GetComponent<T>().Initialize(child);
            }
        }

        public static void DestroyChildren(this Transform transform) {
            foreach (Transform child in transform) {
                Object.Destroy(child.gameObject);
            }
        }

        public static void SetActiveChildren(this Transform transform, bool active) {
            foreach (Transform child in transform) {
                child.gameObject.SetActive(active);
            }
        }

        public static Transform FindParentIn<T>(this Transform transform) where T : Object {
            while (transform.parent.GetComponent<T>() == null) {
                transform = transform.parent;
            }
            return transform;
        }
    }
}
