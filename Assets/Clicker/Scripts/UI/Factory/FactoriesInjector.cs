using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Clicker
{
    public class FactoriesInjector : MonoBehaviour
    {
        private Common.EnumerableInjector enumerableInjector;

        void Start() {
            this.enumerableInjector = this.GetComponent<Common.EnumerableInjector>();
            this.Reflesh();
        }

        public void Reflesh() {
            this.enumerableInjector.Clear();
            foreach (var factory in Repositories.Instance.FactoryRepository.List()) {
                this.Add(factory);
            }
            var buyableFactory = Repositories.Instance.FactoryRepository.GetBuyable();
            if (buyableFactory != null) {
                this.AddBuyable(buyableFactory);
            }
        }

        public void Add(Factory factory) {
            this.enumerableInjector.Inject(
                new FactoryAdapter(factory, this),
                "Clicker/UI/Parts/Factory"
            );
        }

        public void AddBuyable(Factory factory) {
            this.enumerableInjector.Inject(
                new FactoryAdapter(factory, this),
                "Clicker/UI/Parts/BuyableFactory"
            );
        }
    }
}
