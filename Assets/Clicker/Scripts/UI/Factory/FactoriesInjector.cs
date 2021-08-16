using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Clicker
{
    public class FactoriesInjector : MonoBehaviour
    {
        private Common.EnumerableInjector enumerableInjector;
        private List<Factory> factories = new List<Factory>();

        void Start() {
            this.enumerableInjector = this.GetComponent<Common.EnumerableInjector>();
            this.enumerableInjector.Clear();
            var repository = Repositories.Instance.FactoryRepository;
            foreach (var factory in repository.List()) {
                this.Inject(factory);
            }
            foreach (var factory in repository.ListBuyable()) {
                this.Inject(factory);
            }
        }

        public void Inject(Factory factory) {
            if (this.factories.Any(t => t.EqualsFactory(factory))) {
                return;
            }
            this.enumerableInjector.Inject(
                new FactoryAdapter(factory, this),
                "Clicker/UI/Parts/Factory"
            );
            this.factories.Add(factory);
        }
    }
}
