using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common
{
    public class OpenModalButton : MonoBehaviour
    {
        [SerializeField]
        private GameObject modal;

        public void Open() {
            Instantiate(modal, this.GetComponentInParent<Canvas>().gameObject.transform);
        }
    }
}
