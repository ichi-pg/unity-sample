using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            Common.Hierarchy.DestroyChildren(this.parent);
            Common.Hierarchy.InstantiateChildren<GadgetView, IGadget>(
                this.parent,
                this.prefab,
                DIContainer.FromGadgetCategory(this.category).Factories
            );
        }
    }
}
