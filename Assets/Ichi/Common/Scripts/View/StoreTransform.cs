using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ichi.Common
{
    public struct StoreTransform
    {
        private Vector3 position;
        private Quaternion rotation;
        private Vector3 scale;

        public void Store(Transform transform) {
            this.position = transform.localPosition;
            this.rotation = transform.localRotation;
            this.scale = transform.localScale;
        }

        public void Restore(Transform transform) {
            transform.localPosition = this.position;
            transform.localRotation = this.rotation;
            transform.localScale = this.scale;
        }
    }
}
