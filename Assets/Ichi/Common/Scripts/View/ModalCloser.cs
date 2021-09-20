using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ichi.Common.Extensions;

namespace Ichi.Common
{
    public class ModalCloser : MonoBehaviour
    {
        public void Close() {
            var modal = this.transform.FindParentIn<Canvas>().gameObject;
            var animation = modal.GetComponentInChildren<ModalAnimation>();
            if (animation == null) {
                Destroy(modal);
            } else {
                animation.Close(() => {
                    Destroy(modal);
                });
            }
        }
    }
}
