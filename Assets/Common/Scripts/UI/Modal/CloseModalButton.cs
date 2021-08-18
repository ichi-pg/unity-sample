using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common
{
    public class CloseModalButton : MonoBehaviour
    {
        [SerializeField]
        private GameObject modal;

        public void Close() {
            Destroy(modal);
        }
    }
}
