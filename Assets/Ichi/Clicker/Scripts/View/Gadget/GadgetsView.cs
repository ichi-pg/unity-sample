using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ichi.Common.Extensions;

namespace Ichi.Clicker.View
{
    public class GadgetsView : MonoBehaviour
    {
        [SerializeField]
        private GameObject prefab;
        [SerializeField]
        private Transform parent;

        [SerializeField]
        private GadgetCategory category;

        void Start() {
            this.parent.DestroyChildren();
            this.parent.InstantiateChildren<GadgetView, IGadget>(
                this.prefab,
                DIContainer.FromGadgetCategory(this.category).Gadgets
            );
        }
    }
}
