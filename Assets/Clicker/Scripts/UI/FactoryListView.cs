using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Clicker
{
    public class FactoryListView : Common.EnumerableInjector
    {
        void Start() {
            this.Clear();
            this.Inject(
                Repositories.Instance.FactoryRepository.List(),
                "Clicker/UI/Parts/Factory"
            );
            this.Inject(
                new List<Factory>() {
                    Repositories.Instance.FactoryRepository.GetBuyable(),
                },
                "Clicker/UI/Parts/BuyableFactory"
            );
        }
    }
}
