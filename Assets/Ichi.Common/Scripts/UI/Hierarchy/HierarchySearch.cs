using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common
{
    public static class HierarchySearch
    {
        public static Transform FindParentIn<T>(Transform transform) where T : Object {
            while (transform.parent.GetComponent<T>() == null) {
                transform = transform.parent;
            }
            return transform;
        }
    }
}
