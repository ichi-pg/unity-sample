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
        private IItem item;

        void Start() {
            this.item = DIContainer.ItemRepository.GetItem(this.category);
            this.item.OnAlter.Subscribe(_ => this.OnAlter()).AddTo(this);
            this.OnAlter();
        }

        private void OnAlter() {
            this.text.text = Common.Texts.ToString(this.item.Quantity);
        }
    }
}
