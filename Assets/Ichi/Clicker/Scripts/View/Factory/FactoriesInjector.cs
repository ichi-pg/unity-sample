using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ichi.Clicker
{
    [RequireComponent(typeof(Common.EnumerableInjector))]
    public class FactoriesInjector : MonoBehaviour
    {
        [SerializeField]
        private GameObject prefab;

        void Start() {
            var enumerableInjector = this.GetComponent<Common.EnumerableInjector>();
            enumerableInjector.Clear();
            foreach (var factory in DIContainer.FactoryRepository.Factories) {
                enumerableInjector.Inject(
                    new FactoryAdapter(factory),
                    this.prefab,
                    DIContainer.ResourceLoader
                );
            }
        }
    }
}
