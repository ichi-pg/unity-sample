using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Clicker
{
    public class FactoryListView : Common.EnumerableInjector
    {
        void Start() {
            this.Reflesh();
        }

        public void Reflesh() {
            this.Clear();
            this.InjectList(
                Repositories.Instance.FactoryRepository.List(),
                "Clicker/UI/Parts/Factory"
            );
            this.Inject(
                Repositories.Instance.FactoryRepository.GetBuyable(),
                "Clicker/UI/Parts/BuyableFactory"
            );
        }
    }
}
