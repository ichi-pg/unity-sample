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
            var repository = Repositories.Instance.FactoryRepository;
            foreach (var factory in repository.List()) {
                this.Inject(factory);
            }
            var buyableFactory = repository.GetBuyable();
            if (buyableFactory != null) {
                this.Inject(buyableFactory);
            }
        }

        public void Inject(Factory factory) {
            this.enumerableInjector.Inject(
                new FactoryAdapter(factory, this),
                "Clicker/UI/Parts/Factory"
            );
        }
    }
}
