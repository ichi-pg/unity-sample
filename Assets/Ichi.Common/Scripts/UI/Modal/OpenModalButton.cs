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
            Instantiate(this.modal, this.GetComponentInParent<Canvas>().transform);
            //TODO データ注入
            //TODO 入れ替えるパターン
        }
    }
}
