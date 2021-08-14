using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Clicker
{
    public class FactoryListView : MonoBehaviour
    {
        private Common.EnumerableInjector EnumerableInjector { get => this.GetComponent<Common.EnumerableInjector>(); }

        void Start() {
            this.Reflesh();
        }

        public void Reflesh() {
            this.EnumerableInjector.Clear();
            this.EnumerableInjector.InjectList(
                Repositories.Instance.FactoryRepository.List(),
                "Clicker/UI/Parts/Factory"
            );
            this.EnumerableInjector.Inject(
                Repositories.Instance.FactoryRepository.GetBuyable(),
                "Clicker/UI/Parts/BuyableFactory"
            );
        }
    }
}
