using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ichi.Common
{
    public class ModalCloser : MonoBehaviour
    {
        public void Close() {
            Destroy(Hierarchy.FindParentIn<Canvas>(this.transform).gameObject);
        }
    }
}
