using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Ichi.Clicker.View
{
    public class ItemView : MonoBehaviour
    {
        [SerializeField]
        private Text text;
        [SerializeField]
        private ItemCategory category;

        void Start() {
            DIContainer.FromItemCategory(this.category).Item.AlterHandler += this.OnAlter;
            this.OnAlter();
        }

        void OnDestroy() {
            DIContainer.FromItemCategory(this.category).Item.AlterHandler -= this.OnAlter;
        }

        private void OnAlter() {
            this.text.text = Common.BigIntegerText.ToString(DIContainer.FromItemCategory(this.category).Item.Quantity);
        }
    }
}
