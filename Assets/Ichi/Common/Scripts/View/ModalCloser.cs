using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ichi.Common.Extensions;

namespace Ichi.Common
{
    public class ModalCloser : MonoBehaviour
    {
        public void Close() {
            Destroy(this.transform.FindParentIn<Canvas>().gameObject);
        }
    }
}
