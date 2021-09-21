using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

namespace Ichi.Clicker.View
{
    public class CollectButton : MonoBehaviour
    {
        [SerializeField]
        private Button button;

        void Start() {
            this.button.OnClickAsObservable().Subscribe(_ => this.Collect()).AddTo(this);
        }

        private void Collect() {
            DIContainer.CommodityRepository.Collect();
        }
    }
}
