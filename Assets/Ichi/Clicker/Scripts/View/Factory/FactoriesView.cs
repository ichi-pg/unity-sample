using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ichi.Clicker.View
{
    public class FactoriesView : MonoBehaviour
    {
        [SerializeField]
        private GameObject prefab;
        [SerializeField]
        private Transform parent;

        [SerializeField]
        private FactoryCategory category;

        void Start() {
            Common.Hierarchy.DestroyChildren(this.parent);
            Common.Hierarchy.InstantiateChildren<FactoryView, IFactory>(
                this.parent,
                this.prefab,
                DIContainer.FromFactoryCategory(this.category).Factories
            );
        }
    }
}
