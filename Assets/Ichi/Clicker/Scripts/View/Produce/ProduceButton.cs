using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ichi.Clicker
{
    public class ProduceButton : MonoBehaviour
    {
        public void Produce() {
            var repository = DIContainer.FactoryRepository;
            foreach (var factory in repository.ClickFactories) {
                if (factory.IsBought) {
                    repository.Produce(factory);
                }
            }
        }
    }
}
