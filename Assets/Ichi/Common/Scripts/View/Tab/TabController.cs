using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

namespace Ichi.Common
{
    public class TabController : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] views;
        [SerializeField]
        private Button[] buttons;

        void Start() {
            for (var i = 0; i < this.buttons.Length; ++i) {
                var k = i;
                this.buttons[i].OnClickAsObservable().Subscribe(_ =>{
                    for (var j = 0; j < this.views.Length; ++j) {
                        this.views[j].SetActive(j == k);
                    }
                }).AddTo(this);
            }
        }
    }
}
