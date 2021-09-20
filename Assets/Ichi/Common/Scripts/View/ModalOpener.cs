using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
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
            //NOTE 実は全画面モダルだけでヒストリー遷移になる
        }

        public T OpenWith<T>() where T : Component {
            return this.Create().GetComponent<T>();
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
