using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ichi.Common
{
    public class OpenModalButton : MonoBehaviour
    {
        [SerializeField]
        private GameObject modal;

        public void Open() {
            var obj = Instantiate(this.modal, this.GetComponentInParent<Canvas>().transform);
            var parentInjector = this.GetComponentInParent<DataInjector>();
            var childInjector = obj.GetComponentInChildren<DataInjector>();
            if (parentInjector != null && childInjector != null) {
                childInjector.Inject(parentInjector.Data, parentInjector.Loader);
            }
            //TODO 入れ替えるパターン
            //TODO Enumerableだった時バッティングするかも
        }
    }
}
