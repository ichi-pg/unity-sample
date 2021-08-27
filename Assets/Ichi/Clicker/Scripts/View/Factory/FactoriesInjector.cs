using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ichi.Clicker
{
    [RequireComponent(typeof(Ichi.Common.EnumerableInjector))]
    public class FactoriesInjector : MonoBehaviour
    {
        [SerializeField]
        private GameObject prefab;
        private Ichi.Common.EnumerableInjector enumerableInjector;

        void Start() {
            this.enumerableInjector = this.GetComponent<Ichi.Common.EnumerableInjector>();
            this.enumerableInjector.Clear();
            foreach (var factory in DIContainer.FactoryRepository.Factories) {
                this.enumerableInjector.Inject(
                    new FactoryAdapter(factory),
                    this.prefab,
                    DIContainer.ResourceLoader
                );
            }
        }
    }
}
