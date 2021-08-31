using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ichi.Clicker
{
    public class FactoriesView : MonoBehaviour
    {
        [SerializeField]
        private GameObject prefab;

        void Start() {
            Common.Hierarchy.DestroyChildren(this.transform);
            Common.Hierarchy.InstantiateChildren<FactoryView, IFactory>(
                this.transform,
                this.prefab,
                DIContainer.FactoryRepository.Factories
            );
        }
    }
}
