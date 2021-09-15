using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using Zenject;

namespace Ichi.Clicker.View
{
    public class ItemView : MonoBehaviour
    {
        [Inject]
        private IItemRepositories itemRepositories;
        [SerializeField]
        private Text text;
        [SerializeField]
        private ItemCategory category;

        void Start() {
            this.itemRepositories.Get(this.category).Item.OnAlter.Subscribe(_ => this.OnAlter()).AddTo(this);
            this.OnAlter();
        }

        private void OnAlter() {
            this.text.text = Common.BigIntegerText.ToString(this.itemRepositories.Get(this.category).Item.Quantity);
            //TODO ドラムロール
        }
    }
}
