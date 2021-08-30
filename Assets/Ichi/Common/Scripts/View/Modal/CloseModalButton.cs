using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ichi.Common
{
    public class CloseModalButton : MonoBehaviour
    {
        public void Close() {
            Destroy(HierarchySearch.FindParentIn<Canvas>(this.transform).gameObject);
        }
    }
}
