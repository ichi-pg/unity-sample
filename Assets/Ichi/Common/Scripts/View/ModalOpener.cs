using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Ichi.Common
{
    public class ModalOpener : MonoBehaviour
    {
        [SerializeField]
        private GameObject modal;

        public void Open() {
            Instantiate(
                this.modal,
                FindObjectsOfType<Canvas>()
                    .OrderBy(canvas => -canvas.sortingOrder)
                    .FirstOrDefault()
                    .transform
            );
            //TODO IChildView
            //TODO 入れ替えるパターン
        }
    }
}
