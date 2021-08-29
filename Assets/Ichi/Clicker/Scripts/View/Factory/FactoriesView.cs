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
            Common.HierarchyDestroy.DestroyChildren(this.transform);
            foreach (var factory in DIContainer.FactoryRepository.Factories) {
                Instantiate(this.prefab, this.transform)
                    .GetComponent<FactoryView>()?
                    .Initialize(factory);
            }
        }
    }
}
