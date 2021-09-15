using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Ichi.Clicker.View
{
    public class FactoriesView : MonoBehaviour
    {
        [Inject]
        private IFactoryRepositories factoryRepositories;
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
                this.factoryRepositories.Get(this.category).Factories
            );
        }
    }
}
