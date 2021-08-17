using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Clicker
{
    public class FactoriesInjector : MonoBehaviour
    {
        private Common.EnumerableInjector enumerableInjector;

        void Start() {
            this.enumerableInjector = this.GetComponent<Common.EnumerableInjector>();
            this.enumerableInjector.Clear();
            foreach (var factory in Repositories.Instance.FactoryRepository.List()) {
                this.enumerableInjector.Inject(
                    new FactoryAdapter(factory, this),
                    "Clicker/UI/Parts/Factory"
                );
            }
        }
    }
}
