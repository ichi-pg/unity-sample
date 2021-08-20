using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common
{
    public static class HierarchyDestroy
    {
        public static void DestroyChildren(Transform transform) {
            foreach(Transform child in transform){
                Object.Destroy(child.gameObject);
            }
        }
    }
}
