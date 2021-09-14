using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

namespace Ichi.Clicker.View
{
    public class ItemView : MonoBehaviour
    {
        [SerializeField]
        private Text text;
        [SerializeField]
        private ItemCategory category;

        void Start() {
            DIContainer.FromItemCategory(this.category).Item.OnAlter.Subscribe(_ => this.OnAlter()).AddTo(this);
            this.OnAlter();
        }

        private void OnAlter() {
            this.text.text = Common.BigIntegerText.ToString(DIContainer.FromItemCategory(this.category).Item.Quantity);
        }
    }
}
