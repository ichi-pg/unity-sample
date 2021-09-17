using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace Ichi.Common.Extensions
{
    public static class TransformExtensions
    {
        public static void InstantiateChildren<T, U>(this Transform transform, GameObject prefab, IEnumerable<U> children, Action<T, U> initializer) where T : Component {
            foreach (var child in children) {
                initializer(
                    GameObject.Instantiate(prefab, transform).GetComponent<T>(),
                    child
                );
            }
        }

        public static void DestroyChildren(this Transform transform) {
            foreach (Transform child in transform) {
                GameObject.Destroy(child.gameObject);
            }
        }

        public static void SetActiveChildren(this Transform transform, bool active) {
            foreach (Transform child in transform) {
                child.gameObject.SetActive(active);
            }
        }

        public static Transform FindParentIn<T>(this Transform transform) where T : UnityEngine.Object {
            while (transform.parent.GetComponent<T>() == null) {
                transform = transform.parent;
            }
            return transform;
        }
    }
}
