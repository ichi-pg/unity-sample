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
            this.Create();
            //NOTE 入れ替えるパターン
        }

        public void Open<T, U>(U child) where T : IChildView<U> {
            this.Create().GetComponent<T>().Initialize(child);
        }

        private GameObject Create() {
            return Instantiate(
                this.modal,
                FindObjectsOfType<Canvas>()
                    .OrderBy(canvas => -canvas.sortingOrder)
                    .FirstOrDefault()
                    .transform
            );
        }
    }
}
