using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Clicker
{
    [RequireComponent(typeof(Common.EnumerableInjector))]
    public class FactoriesInjector : MonoBehaviour
    {
        [SerializeField]
        private GameObject prefab;
        private Common.EnumerableInjector enumerableInjector;

        void Start() {
            this.enumerableInjector = this.GetComponent<Common.EnumerableInjector>();
            this.enumerableInjector.Clear();
            foreach (var factory in Repositories.Instance.FactoryRepository.List()) {
                this.enumerableInjector.Inject(
                    new FactoryAdapter(factory, this),
                    this.prefab,
                    ResourceLoader.Instance
                );
            }
        }
    }
}
